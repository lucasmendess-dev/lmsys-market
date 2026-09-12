# LMSys Market
## Arquitetura do Sistema

**Documento:** Arquitetura de Software  
**Versão:** 0.1  
**Status:** Arquitetura inicial  
**Produto:** LMSys Market  
**Plataforma:** Windows Desktop  
**Tecnologia principal:** C# / .NET 10 / WPF

---

# 1. Objetivo

Este documento define a arquitetura inicial do **LMSys Market**.

O LMSys Market será uma aplicação desktop profissional destinada à gestão de supermercados e estabelecimentos varejistas.

A arquitetura deverá priorizar:

- separação de responsabilidades;
- facilidade de manutenção;
- testabilidade;
- segurança;
- desempenho;
- escalabilidade;
- baixo acoplamento;
- integridade dos dados;
- suporte a múltiplos usuários;
- suporte a múltiplos terminais;
- possibilidade de evolução para múltiplas lojas;
- integração futura com equipamentos e serviços externos.

---

# 2. Visão geral

O LMSys Market utilizará uma arquitetura em camadas inspirada nos princípios de **Clean Architecture**.

A solução será inicialmente composta pelos seguintes projetos:

```text
LMSys.Market
│
├── LMSys.Market.Domain
├── LMSys.Market.Application
├── LMSys.Market.Infrastructure
└── LMSys.Market.Desktop
```

Além dos projetos responsáveis pelos testes:

```text
tests/
│
├── LMSys.Market.Domain.Tests
├── LMSys.Market.Application.Tests
└── LMSys.Market.Infrastructure.Tests
```

A estrutura física inicial do repositório será:

```text
lmsys-market/
│
├── docs/
│
├── src/
│   ├── LMSys.Market.Domain/
│   ├── LMSys.Market.Application/
│   ├── LMSys.Market.Infrastructure/
│   └── LMSys.Market.Desktop/
│
├── tests/
│   ├── LMSys.Market.Domain.Tests/
│   ├── LMSys.Market.Application.Tests/
│   └── LMSys.Market.Infrastructure.Tests/
│
├── LMSys.Market.sln
├── .gitignore
└── README.md
```

---

# 3. Fluxo geral da aplicação

A comunicação principal seguirá este fluxo:

```text
┌─────────────────────────────────────┐
│         LMSys.Market.Desktop        │
│                                     │
│ Views                               │
│ ViewModels                          │
│ Navegação                           │
│ Componentes visuais                 │
└─────────────────┬───────────────────┘
                  │
                  ▼
┌─────────────────────────────────────┐
│       LMSys.Market.Application      │
│                                     │
│ Casos de uso                        │
│ Serviços                            │
│ DTOs                                │
│ Interfaces                          │
│ Validações                          │
└─────────────────┬───────────────────┘
                  │
                  ▼
┌─────────────────────────────────────┐
│          LMSys.Market.Domain        │
│                                     │
│ Entidades                           │
│ Value Objects                       │
│ Enums                               │
│ Regras de negócio                   │
└─────────────────────────────────────┘

                  ▲
                  │
┌─────────────────┴───────────────────┐
│    LMSys.Market.Infrastructure      │
│                                     │
│ Entity Framework Core               │
│ PostgreSQL                          │
│ Repositories                        │
│ Persistência                        │
│ Logging                             │
│ Integrações                         │
└─────────────────────────────────────┘
```

---

# 4. Regra de dependência

A principal regra arquitetural será:

> As camadas mais internas não deverão depender das camadas externas.

O projeto `Domain` representa o núcleo do sistema e deverá permanecer independente de tecnologias específicas.

O Domain não deverá depender diretamente de:

- WPF;
- Entity Framework Core;
- PostgreSQL;
- interface gráfica;
- bibliotecas de UI;
- equipamentos físicos;
- APIs externas;
- implementações específicas de infraestrutura.

---

# 5. Dependências entre projetos

A estrutura inicial de dependências será:

```text
Domain
  ↑
  │
Application
  ↑
  │
  ├──────── Infrastructure
  │
  └──────── Desktop
```

Mais especificamente:

```text
LMSys.Market.Domain
    Nenhuma dependência dos demais projetos LMSys Market.

LMSys.Market.Application
    → LMSys.Market.Domain

LMSys.Market.Infrastructure
    → LMSys.Market.Application
    → LMSys.Market.Domain

LMSys.Market.Desktop
    → LMSys.Market.Application
    → LMSys.Market.Infrastructure
```

O projeto Desktop utilizará Infrastructure principalmente na inicialização da aplicação e na configuração da injeção de dependência.

---

# 6. LMSys.Market.Domain

O projeto `LMSys.Market.Domain` representará o núcleo do negócio.

Ele deverá conter os conceitos e regras que continuam existindo independentemente da interface gráfica, banco de dados ou tecnologia utilizada.

Estrutura inicial:

```text
LMSys.Market.Domain/
│
├── Entities/
├── Enums/
├── ValueObjects/
├── Exceptions/
├── Rules/
└── Common/
```

---

# 7. Entidades

As entidades representam elementos importantes do domínio do supermercado.

Entre as principais entidades previstas estão:

```text
Usuario
Perfil
Permissao

Produto
Categoria
Marca
UnidadeMedida
CodigoBarras

Estoque
MovimentacaoEstoque
Lote

Fornecedor

PedidoCompra
ItemPedidoCompra
RecebimentoCompra

Cliente

Venda
ItemVenda
Pagamento

Caixa
SessaoCaixa
Sangria
Suprimento

Promocao

Inventario
ItemInventario

Perda

ContaPagar
ContaReceber
CategoriaFinanceira

HistoricoPreco

AuditLog
```

As entidades deverão possuir comportamento sempre que existirem regras de negócio relacionadas a elas.

---

# 8. Domínio rico

Sempre que fizer sentido, evitaremos utilizar entidades apenas como recipientes de dados.

Por exemplo, em vez de alterar diretamente o estado de uma venda:

```csharp
venda.Status = StatusVenda.Finalizada;
```

preferiremos comportamentos como:

```csharp
venda.Finalizar();
```

Dessa forma, as regras necessárias para finalizar uma venda poderão ser protegidas pelo próprio domínio.

Exemplos de validações que poderão existir dentro desse comportamento:

- impedir venda sem itens;
- impedir venda já cancelada;
- impedir finalização duplicada;
- verificar valores;
- alterar o status corretamente.

---

# 9. Value Objects

Conceitos sem identidade própria poderão ser representados através de **Value Objects**.

Exemplos futuros:

```text
Money
Cpf
Cnpj
Email
Endereco
Percentual
CodigoBarras
```

Um Value Object deverá representar um valor válido do domínio e poderá concentrar suas próprias validações.

---

# 10. Enums

Estados conhecidos e controlados deverão utilizar enums quando apropriado.

Exemplo:

```text
StatusVenda

Aberta
Finalizada
Cancelada
```

Outro exemplo:

```text
TipoMovimentacaoEstoque

Entrada
Saida
Ajuste
```

Formas de pagamento:

```text
FormaPagamento

Dinheiro
Pix
CartaoDebito
CartaoCredito
```

Outros enums serão adicionados conforme os módulos forem implementados.

---

# 11. LMSys.Market.Application

A camada `Application` será responsável pelos casos de uso do sistema.

Estrutura inicial:

```text
LMSys.Market.Application/
│
├── DTOs/
├── Interfaces/
├── Services/
├── UseCases/
├── Validators/
├── Mappings/
└── Common/
```

---

# 12. Responsabilidades da Application

A camada Application deverá coordenar ações do sistema.

Exemplos de casos de uso:

```text
CadastrarProduto
AtualizarProduto
PesquisarProdutos

AbrirCaixa
RealizarSangria
RealizarSuprimento
FecharCaixa

CriarPedidoCompra
ReceberPedido

CriarVenda
AdicionarItemVenda
FinalizarVenda
CancelarVenda

RegistrarPerda

CriarInventario
FinalizarInventario
```

A camada Application não deverá conter código diretamente relacionado a:

- WPF;
- PostgreSQL;
- controles visuais;
- janelas;
- componentes gráficos.

---

# 13. DTOs

DTO significa **Data Transfer Object**.

Utilizaremos DTOs quando for necessário transportar dados entre camadas sem expor diretamente todos os detalhes das entidades.

Exemplo:

```text
ProdutoDto

Id
Codigo
Descricao
Categoria
PrecoVenda
EstoqueAtual
Ativo
```

Isso permite que a interface receba apenas as informações necessárias.

---

# 14. Interfaces

Contratos necessários para executar casos de uso serão definidos principalmente na camada Application.

Exemplos:

```text
IProdutoRepository
IVendaRepository
IEstoqueRepository
IFornecedorRepository
IClienteRepository
IPedidoCompraRepository

IUnitOfWork

IAuthenticationService
ILoggerService
IDateTimeProvider
```

As implementações concretas ficarão principalmente em Infrastructure.

Exemplo:

```text
Application

IProdutoRepository
        │
        ▼
Infrastructure

ProdutoRepository
```

---

# 15. LMSys.Market.Infrastructure

O projeto `Infrastructure` será responsável pela comunicação com recursos externos ao domínio.

Estrutura inicial:

```text
LMSys.Market.Infrastructure/
│
├── Data/
│   ├── Context/
│   ├── Configurations/
│   ├── Migrations/
│   └── Seed/
│
├── Repositories/
├── Services/
├── Logging/
└── Integrations/
```

Entre suas responsabilidades estarão:

- acesso ao PostgreSQL;
- Entity Framework Core;
- repositories;
- migrations;
- transações;
- logging;
- persistência;
- integrações externas;
- implementações de interfaces da Application.

---

# 16. Entity Framework Core

O **Entity Framework Core** será utilizado como ORM principal.

Entre suas responsabilidades estarão:

- mapeamento das entidades;
- persistência;
- consultas;
- relacionamentos;
- migrations;
- transações;
- controle de alterações.

A utilização do Entity Framework não deverá fazer com que regras importantes de negócio fiquem espalhadas pela Infrastructure.

---

# 17. PostgreSQL

O **PostgreSQL** será inicialmente o banco de dados principal do LMSys Market.

A escolha permite trabalhar com:

- múltiplos usuários;
- múltiplos computadores;
- grande volume de dados;
- transações;
- integridade referencial;
- concorrência;
- índices;
- backups;
- expansão futura.

O sistema deverá permitir vários computadores conectados ao mesmo servidor PostgreSQL.

Exemplo:

```text
                     ┌───────────────────┐
                     │    PostgreSQL     │
                     │      Server       │
                     └─────────┬─────────┘
                               │
             ┌─────────────────┼─────────────────┐
             │                 │                 │
             ▼                 ▼                 ▼
         Caixa 01          Caixa 02          Gerência
             │                 │                 │
             ▼                 ▼                 ▼
       LMSys Market       LMSys Market       LMSys Market
```

Também poderão utilizar o sistema:

```text
Estoque
Compras
Financeiro
Administração
Gerência
```

---

# 18. DbContext

O acesso principal ao banco de dados será realizado através de um contexto.

O nome inicial será:

```text
LMSysMarketDbContext
```

Ele ficará na camada Infrastructure.

Estrutura prevista:

```text
Infrastructure/
└── Data/
    └── Context/
        └── LMSysMarketDbContext.cs
```

---

# 19. Mapeamentos do Entity Framework

As configurações das entidades deverão preferencialmente utilizar classes específicas.

Exemplos:

```text
ProdutoConfiguration
CategoriaConfiguration
VendaConfiguration
ItemVendaConfiguration
EstoqueConfiguration
ClienteConfiguration
FornecedorConfiguration
```

Deverá ser evitada a concentração excessiva de configurações dentro do método:

```csharp
OnModelCreating()
```

As configurações separadas facilitarão manutenção e crescimento do sistema.

---

# 20. Migrations

Alterações estruturais no banco serão controladas através de migrations.

Exemplos:

```text
InitialCreate
AddProducts
AddInventory
AddSuppliers
AddPurchases
AddSales
AddFinancial
```

As migrations deverão ser versionadas junto com o código no Git.

---

# 21. Repositories

Repositories serão utilizados quando ajudarem a representar operações de persistência relevantes.

Exemplo:

```text
IProdutoRepository
```

Implementação:

```text
ProdutoRepository
```

Não criaremos uma arquitetura excessivamente abstrata apenas por padrão.

Repositories genéricos complexos não serão utilizados sem necessidade real.

Consultas específicas deverão ser criadas de acordo com as necessidades do domínio.

---

# 22. Unit of Work

Operações importantes que alterem várias informações deverão utilizar controle transacional.

Por exemplo, finalizar uma venda poderá alterar:

```text
Finalizar Venda
      │
      ├── Venda
      ├── Itens da venda
      ├── Pagamentos
      ├── Estoque
      ├── Movimentações de estoque
      └── Caixa
```

Essas operações deverão ser confirmadas em conjunto.

Se alguma etapa crítica falhar:

```text
ROLLBACK
```

Nenhuma parte da operação deverá permanecer salva de forma inconsistente.

---

# 23. Concorrência

O sistema deverá considerar que vários usuários poderão trabalhar simultaneamente.

Exemplo:

```text
Caixa 01 vende Coca-Cola
        +
Caixa 02 vende Coca-Cola
        +
Estoquista recebe Coca-Cola
```

Essas operações poderão acontecer praticamente ao mesmo tempo.

A arquitetura deverá impedir problemas como:

- perda de atualização;
- quantidade incorreta;
- estoque inconsistente;
- vendas duplicadas;
- alteração incorreta de estados.

Estratégias específicas de concorrência serão definidas durante os módulos correspondentes.

---

# 24. LMSys.Market.Desktop

O projeto `Desktop` será a aplicação WPF utilizada pelos usuários.

Estrutura planejada:

```text
LMSys.Market.Desktop/
│
├── Views/
├── ViewModels/
├── Controls/
├── Components/
├── Styles/
├── Resources/
├── Themes/
├── Converters/
├── Behaviors/
├── Services/
├── Navigation/
└── Assets/
```

O Desktop será responsável principalmente por:

- apresentação;
- interação com o usuário;
- navegação;
- estado visual;
- atalhos;
- notificações;
- comandos;
- abertura de telas.

---

# 25. MVVM

A aplicação WPF utilizará o padrão:

**Model-View-ViewModel**

Fluxo conceitual:

```text
View
 ↓
ViewModel
 ↓
Application
 ↓
Domain / Infrastructure
```

A View não deverá chamar diretamente o banco de dados.

---

# 26. Views

Uma View deverá ser responsável principalmente pela apresentação visual.

Exemplo:

```text
ProductsView.xaml
```

A View poderá definir:

- layout;
- controles;
- bindings;
- estilos;
- apresentação;
- recursos visuais.

---

# 27. ViewModels

A ViewModel será responsável pelo estado e pelas ações disponíveis na tela.

Exemplo:

```text
ProductsViewModel
```

Responsabilidades possíveis:

```text
Produtos
ProdutoSelecionado
TextoPesquisa

CarregarProdutosCommand
NovoProdutoCommand
EditarProdutoCommand
DesativarProdutoCommand
PesquisarCommand
```

A ViewModel deverá utilizar serviços da Application para realizar operações.

---

# 28. Code-behind

Code-behind não será completamente proibido.

Entretanto, deverá ser utilizado somente quando necessário para comportamentos diretamente relacionados à interface.

Regras de negócio não deverão ficar nos arquivos:

```text
*.xaml.cs
```

Exemplos aceitáveis de code-behind podem incluir determinados comportamentos puramente visuais que sejam difíceis ou desnecessariamente complexos de implementar através de MVVM.

---

# 29. Navegação

A aplicação administrativa possuirá uma janela principal.

Estrutura conceitual:

```text
MainWindow
│
├── Sidebar
├── Header
└── ContentArea
```

O conteúdo principal será alterado conforme o módulo selecionado.

Exemplo:

```text
Dashboard
PDV
Produtos
Estoque
Compras
Clientes
Financeiro
Relatórios
Usuários
Auditoria
Configurações
```

---

# 30. Interface profissional

O LMSys Market deverá possuir aparência compatível com softwares empresariais modernos.

Deverá ser evitado o aspecto visual de uma aplicação composta apenas por controles padrão do Windows.

A interface deverá possuir:

- identidade visual;
- hierarquia;
- consistência;
- alinhamento;
- espaçamentos padronizados;
- tipografia consistente;
- componentes reutilizáveis;
- ícones;
- feedback visual.

---

# 31. Design System

O LMSys Market possuirá um Design System próprio.

Entre os componentes previstos estão:

```text
PrimaryButton
SecondaryButton
DangerButton
IconButton

TextInput
PasswordInput
SearchInput

Select
ComboBox

DataGrid

Card
MetricCard

Badge

Dialog
ConfirmationDialog

Toast

LoadingIndicator

EmptyState

SidebarItem

Pagination
```

Os componentes deverão ser reutilizados sempre que possível.

---

# 32. Recursos visuais

Recursos compartilhados deverão ser centralizados.

Estrutura possível:

```text
Resources/
│
├── Colors.xaml
├── Typography.xaml
├── Buttons.xaml
├── Inputs.xaml
├── DataGrid.xaml
├── Cards.xaml
├── Dialogs.xaml
└── Icons.xaml
```

Isso permitirá alterar elementos visuais globalmente sem modificar cada tela individualmente.

---

# 33. Aparência do administrativo

A interface administrativa terá uma estrutura semelhante a:

```text
┌───────────────────────────────────────────────────────────────┐
│ LMSys Market                               Usuário conectado  │
├───────────────┬───────────────────────────────────────────────┤
│               │                                               │
│ Dashboard     │ Dashboard                                     │
│               │                                               │
│ PDV           │ ┌──────────┐ ┌──────────┐ ┌──────────┐       │
│ Produtos      │ │ Vendas   │ │ Receita  │ │ Ticket   │       │
│ Estoque       │ └──────────┘ └──────────┘ └──────────┘       │
│ Compras       │                                               │
│ Clientes      │                 Gráfico                       │
│ Financeiro    │                                               │
│ Relatórios    │                                               │
│ Usuários      │                                               │
│ Auditoria     │                                               │
│ Configurações │                                               │
│               │                                               │
└───────────────┴───────────────────────────────────────────────┘
```

A interface deverá utilizar principalmente:

- menu lateral;
- barra superior;
- área central de conteúdo;
- cards;
- tabelas;
- filtros;
- formulários;
- modais;
- gráficos.

---

# 34. PDV

O módulo de PDV terá uma interface especializada.

O objetivo principal será:

- velocidade;
- simplicidade;
- legibilidade;
- operação através do teclado;
- pouca dependência do mouse;
- visualização clara do total;
- feedback imediato.

Exemplo conceitual:

```text
┌───────────────────────────────────────────────────────────────┐
│ LMSys Market PDV          Caixa 01          Operador: Lucas   │
├─────────────────────────────────────────┬─────────────────────┤
│                                         │                     │
│ Código / Produto                        │ TOTAL               │
│                                         │                     │
│ [_________________________________]     │ R$ 187,45           │
│                                         │                     │
│ Produto             Qtd       Total     │                     │
│ Coca-Cola 2L         2       21,98      │                     │
│ Arroz 5kg            1       29,90      │ F2 Cliente          │
│ Feijão               2       17,98      │ F3 Quantidade       │
│                                         │ F4 Desconto         │
│                                         │ F5 Pagamento        │
│                                         │ F8 Cancelar Item    │
│                                         │ F10 Finalizar       │
└─────────────────────────────────────────┴─────────────────────┘
```

---

# 35. Atalhos do PDV

O PDV deverá priorizar atalhos de teclado.

A definição definitiva será realizada durante o desenvolvimento do módulo.

Configuração inicial sugerida:

```text
F2   Cliente
F3   Quantidade
F4   Desconto
F5   Pagamento
F8   Cancelar item
F10  Finalizar venda
Esc  Cancelar / voltar
```

Outros atalhos poderão ser adicionados conforme testes de usabilidade.

---

# 36. Injeção de dependência

A aplicação utilizará injeção de dependência.

Exemplo:

```text
IProdutoRepository
        ↓
ProdutoRepository
```

Outro exemplo:

```text
IAuthenticationService
        ↓
AuthenticationService
```

As implementações serão registradas durante a inicialização da aplicação.

A interface deverá receber suas dependências através de mecanismos apropriados em vez de criá-las manualmente em diversas partes do código.

---

# 37. Logging

O LMSys Market deverá possuir logging técnico.

Os logs poderão registrar:

- inicialização da aplicação;
- encerramento;
- erros;
- exceções;
- problemas de banco;
- falhas de conexão;
- problemas em integrações;
- eventos técnicos relevantes.

O logging será utilizado principalmente para diagnóstico e manutenção.

---

# 38. Logging e Auditoria

Logging e auditoria possuem finalidades diferentes.

## Logging

Voltado para diagnóstico técnico.

Exemplo:

```text
Falha ao conectar ao servidor PostgreSQL.
```

## Auditoria

Voltada para rastreabilidade das operações do negócio.

Exemplo:

```text
Usuário gerente01 alterou o preço do produto 145
de R$ 19,90 para R$ 21,50.
```

Os dois mecanismos deverão permanecer separados conceitualmente.

---

# 39. Tratamento de erros

Falhas deverão ser tratadas de maneira consistente.

O usuário não deverá receber diretamente mensagens técnicas como:

```text
NpgsqlException
DbUpdateException
NullReferenceException
InvalidOperationException
```

A interface deverá exibir mensagens compreensíveis.

Exemplo:

```text
Não foi possível concluir a operação.

Tente novamente. Caso o problema continue,
entre em contato com o administrador.
```

Detalhes técnicos deverão permanecer registrados nos logs.

---

# 40. Validação

A validação poderá ocorrer em diferentes níveis.

```text
Interface
    ↓
Application
    ↓
Domain
    ↓
Database
```

Cada camada terá responsabilidades diferentes.

## Interface

Responsável por feedback rápido ao usuário.

Exemplos:

- campo obrigatório;
- formato inválido;
- valor vazio.

## Application

Responsável por validar requisitos de execução de determinado caso de uso.

## Domain

Responsável por proteger regras importantes do negócio.

## Database

Responsável por proteger integridade estrutural e relacional.

---

# 41. Integridade no banco

O banco de dados deverá possuir mecanismos próprios de integridade.

Exemplos:

- Primary Keys;
- Foreign Keys;
- Unique Constraints;
- campos obrigatórios;
- índices;
- relacionamentos;
- restrições apropriadas.

O banco não deverá depender exclusivamente da interface para manter informações válidas.

---

# 42. Datas e horários

A manipulação de datas deverá ser tratada de maneira consistente.

A arquitetura deverá considerar:

- data local;
- horário utilizado pelo sistema;
- auditoria;
- servidor;
- múltiplos terminais;
- futura utilização em múltiplas lojas.

Poderá ser criada posteriormente uma abstração como:

```text
IDateTimeProvider
```

Isso também facilitará testes automatizados.

---

# 43. Valores monetários

Valores financeiros deverão utilizar:

```csharp
decimal
```

Não deverão ser utilizados:

```csharp
float
double
```

para valores monetários.

Isso se aplica a valores como:

- preços;
- custos;
- descontos;
- pagamentos;
- receitas;
- despesas;
- totais.

---

# 44. Identificadores

A escolha definitiva dos identificadores será realizada durante a modelagem do banco.

Poderemos utilizar identificadores numéricos para grande parte das entidades internas.

Exemplo:

```text
long
```

Poderemos avaliar GUIDs quando houver benefício arquitetural real.

A decisão deverá considerar:

- desempenho;
- tamanho dos índices;
- sincronização futura;
- multi-loja;
- volume de registros.

---

# 45. Exclusão lógica

Entidades envolvidas em histórico operacional deverão preferencialmente ser desativadas em vez de removidas fisicamente.

Exemplos:

```text
Produto
Fornecedor
Cliente
Usuario
Categoria
Marca
```

Uma abordagem comum será:

```text
Ativo = false
```

Isso evita destruir relações históricas.

---

# 46. Segurança

A arquitetura deverá contemplar:

- autenticação;
- autorização;
- hash seguro de senha;
- usuários;
- perfis;
- permissões;
- auditoria;
- validação de dados;
- princípio do menor privilégio.

Não será suficiente esconder um botão da interface.

A operação também deverá ser validada antes da execução.

---

# 47. Autenticação

O usuário deverá se autenticar antes de acessar funcionalidades protegidas.

A sessão deverá manter informações como:

```text
UsuarioId
Nome
Perfil
Permissoes
```

Senhas nunca deverão ser armazenadas em texto puro.

---

# 48. Autorização

O sistema deverá validar se o usuário possui permissão antes de realizar operações protegidas.

Exemplos:

```text
Produtos.Visualizar
Produtos.Cadastrar
Produtos.Editar

Estoque.Ajustar

Venda.Cancelar

Caixa.Sangria

Financeiro.Visualizar

Usuarios.Gerenciar
```

A estrutura definitiva será desenvolvida no módulo de autenticação e segurança.

---

# 49. Testes

O projeto possuirá testes automatizados.

Estrutura inicial:

```text
tests/
│
├── LMSys.Market.Domain.Tests
├── LMSys.Market.Application.Tests
└── LMSys.Market.Infrastructure.Tests
```

---

# 50. Testes de Domain

Testes de Domain deverão validar principalmente regras de negócio.

Exemplos:

```text
Venda não pode ser finalizada sem itens.

Quantidade de item não pode ser menor ou igual a zero.

Produto inativo não pode ser vendido.

Venda cancelada não pode ser finalizada.

Perda precisa possuir quantidade válida.
```

Esses testes não deverão depender do WPF.

---

# 51. Testes de Application

Os testes da camada Application deverão validar casos de uso.

Exemplo:

```text
FinalizarVenda
```

Poderemos verificar:

```text
Venda registrada
Itens registrados
Pagamento registrado
Movimentação de estoque criada
Caixa atualizado
```

---

# 52. Testes de Infrastructure

Os testes de Infrastructure poderão validar:

- mapeamentos;
- repositories;
- consultas;
- persistência;
- constraints;
- transações;
- integração com o banco.

---

# 53. Estratégia de desenvolvimento

O LMSys Market será desenvolvido através de módulos.

A sequência inicial será:

```text
00 - Foundation

01 - Products

02 - Inventory

03 - Suppliers & Purchases

04 - POS

05 - Cash Register

06 - Customers

07 - Financial

08 - Promotions

09 - Inventory & Losses

10 - Dashboard & Reports

11 - Audit & Security
```

---

# 54. Módulo 00 — Foundation

O primeiro módulo será responsável pela fundação do sistema.

Deverá contemplar inicialmente:

- solução .NET;
- projetos;
- referências;
- injeção de dependência;
- PostgreSQL;
- Entity Framework Core;
- configuração;
- estrutura MVVM;
- Design System inicial;
- splash screen;
- login;
- sessão do usuário;
- janela principal;
- menu lateral;
- navegação;
- dashboard inicial;
- logout.

Ao final do módulo, o LMSys Market deverá abrir e ser utilizável para testes.

---

# 55. Estado funcional

Após cada módulo, a aplicação deverá permanecer funcional.

Exemplo:

```text
Foundation
     ↓
Programa abre
Login funciona
Dashboard funciona

Products
     ↓
Programa abre
Login funciona
Produtos funcionam

Inventory
     ↓
Produtos funcionam
Estoque funciona

Purchases
     ↓
Compra realizada
Estoque atualizado

POS
     ↓
Venda realizada
Estoque baixado
Pagamento registrado
```

Não serão desenvolvidos diversos módulos desconectados para somente depois tentar integrá-los.

---

# 56. Critério de conclusão de módulo

Um módulo somente será considerado concluído quando estiver:

- implementado;
- integrado;
- funcional;
- visualmente utilizável;
- validado;
- testado;
- documentado;
- versionado no Git.

Quando aplicável, deverá existir também uma forma clara de testar manualmente o fluxo desenvolvido.

---

# 57. Git

O desenvolvimento será versionado com Git.

Branches principais:

```text
main
develop
```

A branch `main` representará versões estáveis.

A branch `develop` será utilizada para integração do desenvolvimento.

Novas funcionalidades poderão utilizar branches:

```text
feature/authentication
feature/products
feature/inventory
feature/purchases
feature/pos
```

Correções poderão utilizar:

```text
fix/nome-da-correcao
```

---

# 58. Commits

Os commits deverão possuir mensagens claras.

Padrão inicial:

```text
feat: adiciona cadastro de produtos

fix: corrige cálculo de estoque

docs: atualiza documentação de arquitetura

refactor: reorganiza serviço de vendas

test: adiciona testes de finalização de venda

chore: configura estrutura inicial da solução
```

---

# 59. Evolução futura para API

A primeira versão Desktop poderá utilizar diretamente Application e Infrastructure.

Entretanto, o Domain e a Application deverão ser desenvolvidos sem dependência direta do WPF.

Isso permitirá futuramente adicionar:

```text
LMSys.Market.Api
```

A arquitetura poderá evoluir para:

```text
Desktop
   │
   │ HTTP
   ▼
LMSys Market API
   │
   ▼
Application
   │
   ▼
Domain
   │
   ▼
Infrastructure
   │
   ▼
PostgreSQL
```

Isso poderá ser importante para:

- múltiplas lojas;
- acesso remoto;
- aplicativos;
- e-commerce;
- marketplaces;
- integrações externas;
- serviços web.

---

# 60. Multi-loja

A primeira versão poderá operar inicialmente com uma única loja.

Entretanto, decisões arquiteturais não deverão impedir uma evolução futura para:

```text
Empresa
   │
   ├── Loja 01
   │      ├── Estoque
   │      ├── Caixa 01
   │      └── Caixa 02
   │
   ├── Loja 02
   │      ├── Estoque
   │      ├── Caixa 01
   │      └── Caixa 02
   │
   └── Loja 03
```

Conceitos como empresa, filial e terminal poderão ser introduzidos quando necessário.

---

# 61. Equipamentos

Integrações com dispositivos físicos deverão ser desacopladas das regras centrais do sistema.

Exemplos futuros:

```text
IBarcodeScanner
IScaleService
IReceiptPrinter
IPaymentTerminal
```

Poderemos ter implementações específicas:

```text
ToledoScaleService
ElginPrinterService
GenericBarcodeScannerService
```

Dessa forma, a troca de um equipamento não exigirá alteração do núcleo da aplicação.

---

# 62. Leitor de código de barras

Leitores que funcionem como entrada de teclado poderão ser utilizados diretamente inicialmente.

Caso seja necessária integração especializada, deverá ser criado um serviço específico.

A regra de identificação do produto não deverá depender do fabricante do leitor.

---

# 63. Balanças

Produtos vendidos por peso poderão futuramente utilizar integração com balanças.

A arquitetura deverá permitir:

- leitura de peso;
- interpretação de etiquetas;
- comunicação com equipamentos;
- configuração por modelo.

Essa integração deverá permanecer isolada do domínio principal.

---

# 64. Impressoras

Impressoras poderão ser utilizadas para:

- comprovantes;
- relatórios;
- etiquetas;
- documentos operacionais.

A lógica de impressão deverá possuir abstrações próprias quando necessária.

---

# 65. Módulo fiscal

Integrações fiscais serão tratadas como uma área própria.

Exemplo futuro:

```text
Fiscal/
│
├── Interfaces/
├── Services/
├── Models/
└── Providers/
```

Regras específicas de NFC-e ou outros modelos não deverão ser espalhadas por toda a aplicação.

---

# 66. Pagamentos externos

Integrações futuras poderão incluir:

- TEF;
- PIX;
- gateways;
- terminais de cartão.

Essas integrações deverão utilizar contratos próprios.

Exemplo:

```text
IPaymentProvider
```

Dessa maneira, o domínio da venda não deverá depender de um fornecedor específico.

---

# 67. Organização por funcionalidade

Conforme a aplicação crescer, algumas camadas poderão ser organizadas por funcionalidade.

Exemplo:

```text
Application/
│
├── Products/
│   ├── Create/
│   ├── Update/
│   ├── Search/
│   └── DTOs/
│
├── Inventory/
│
├── Sales/
│
├── Purchases/
│
├── Customers/
│
└── Financial/
```

Essa organização poderá facilitar a manutenção de projetos maiores.

Ela será adotada quando houver benefício real.

---

# 68. Convenções de nomenclatura

Classes deverão utilizar PascalCase.

Exemplos:

```text
ProductService
SaleService
InventoryService
```

Interfaces deverão iniciar com `I`.

Exemplos:

```text
IProductService
ISaleService
IInventoryService
```

Views:

```text
ProductsView.xaml
ProductFormView.xaml
DashboardView.xaml
```

ViewModels:

```text
ProductsViewModel
ProductFormViewModel
DashboardViewModel
```

Repositories:

```text
ProductRepository
SaleRepository
InventoryRepository
```

---

# 69. Idioma do código

A interface apresentada ao usuário será em **português brasileiro**.

Para o código, utilizaremos preferencialmente inglês para:

- projetos;
- pastas;
- classes técnicas;
- interfaces;
- infraestrutura;
- componentes;
- comandos;
- Views;
- ViewModels.

Exemplos:

```text
Products
Inventory
Sales
Purchases
Customers
Suppliers
Services
Repositories
Commands
Converters
```

A nomenclatura do domínio deverá seguir uma convenção consistente durante todo o projeto.

Não deveremos alternar arbitrariamente entre português e inglês para o mesmo conceito.

---

# 70. Namespaces

Os namespaces deverão acompanhar a estrutura da solução.

Exemplos:

```text
LMSys.Market.Domain.Entities

LMSys.Market.Domain.Enums

LMSys.Market.Application.Products

LMSys.Market.Application.Interfaces

LMSys.Market.Infrastructure.Data

LMSys.Market.Infrastructure.Repositories

LMSys.Market.Desktop.Views

LMSys.Market.Desktop.ViewModels
```

---

# 71. Configurações

Configurações da aplicação não deverão ficar espalhadas pelo código.

Poderemos possuir configurações para:

- conexão com banco;
- logging;
- comportamento da aplicação;
- parâmetros do sistema.

Informações sensíveis não deverão ser versionadas de maneira insegura no repositório.

---

# 72. Inicialização da aplicação

Durante a inicialização serão configurados componentes como:

```text
Configuration
Logging
Database
Repositories
Application Services
Navigation
ViewModels
Views
```

A inicialização deverá permanecer organizada e centralizada.

---

# 73. Seed de dados

Durante o desenvolvimento poderá existir um mecanismo de seed.

Ele poderá criar informações necessárias para executar o sistema pela primeira vez.

Exemplos:

```text
Usuário administrador

Perfis iniciais

Permissões iniciais

Configurações básicas
```

Seeds deverão ser controlados e não poderão criar dados duplicados indiscriminadamente.

---

# 74. Usuário administrador inicial

Durante o desenvolvimento, será necessária uma estratégia segura para criação do primeiro usuário administrador.

Essa estratégia será definida no módulo Foundation.

O sistema não deverá depender permanentemente de uma senha administrativa fixa escrita no código.

---

# 75. Banco em desenvolvimento

O ambiente de desenvolvimento deverá possuir uma configuração própria de banco.

Futuramente poderão existir configurações diferentes:

```text
Development
Testing
Production
```

Isso evitará utilizar dados de produção durante desenvolvimento e testes.

---

# 76. Backup

A arquitetura deverá permitir implementação futura de rotinas de backup.

O backup deverá considerar principalmente o PostgreSQL.

Poderão existir funcionalidades como:

- backup manual;
- backup agendado;
- histórico;
- restauração.

Esse recurso será especificado em etapa posterior.

---

# 77. Performance

A arquitetura deverá considerar operações de alto volume.

Áreas especialmente sensíveis:

- leitura de produtos no PDV;
- pesquisa por código de barras;
- listagem de produtos;
- movimentações;
- relatórios;
- histórico de vendas.

Consultas deverão evitar carregamento desnecessário de milhares de registros na memória.

---

# 78. Paginação

Listagens grandes deverão utilizar estratégias como:

- paginação;
- filtros;
- pesquisa;
- carregamento controlado.

Exemplo:

```text
Produtos

1-50 de 18.432 registros

< Anterior    1 2 3 4 5    Próxima >
```

---

# 79. Índices

O banco deverá possuir índices adequados para consultas frequentes.

Possíveis campos:

```text
CodigoInterno
CodigoBarras
Descricao
CPF
CNPJ
NumeroVenda
DataVenda
ProdutoId
ClienteId
FornecedorId
```

A criação de índices deverá ser orientada pelas necessidades reais das consultas.

---

# 80. Consultas

Para consultas que não alteram dados, poderemos utilizar recursos apropriados do Entity Framework, como consultas sem rastreamento quando fizer sentido.

O objetivo será reduzir consumo desnecessário de memória e melhorar desempenho.

---

# 81. Assincronismo

Operações de banco e tarefas potencialmente demoradas deverão utilizar programação assíncrona quando apropriado.

Exemplos:

```text
Carregar produtos
Pesquisar clientes
Salvar venda
Carregar dashboard
Gerar relatório
```

A interface não deverá congelar desnecessariamente durante operações demoradas.

---

# 82. Feedback de carregamento

A interface deverá indicar operações demoradas.

Exemplos:

```text
Carregando...
Salvando...
Processando venda...
Gerando relatório...
```

Poderemos utilizar:

- progress indicators;
- overlays;
- estados de carregamento;
- bloqueio temporário de ações.

---

# 83. Notificações

A aplicação deverá possuir sistema padronizado de notificações.

Exemplos:

```text
Produto cadastrado com sucesso.

Venda finalizada.

Não foi possível salvar o produto.

Estoque insuficiente.

Sessão expirada.
```

Notificações deverão possuir níveis como:

```text
Success
Information
Warning
Error
```

---

# 84. Confirmações

Operações críticas deverão solicitar confirmação quando apropriado.

Exemplos:

```text
Cancelar venda?

Desativar produto?

Fechar caixa?

Excluir item?

Registrar perda?
```

A confirmação deverá explicar claramente a ação que será realizada.

---

# 85. Auditoria

Operações consideradas importantes deverão gerar registros de auditoria.

Exemplos:

- alteração de preço;
- ajuste de estoque;
- cancelamento de venda;
- sangria;
- fechamento de caixa;
- alteração de permissões;
- descontos relevantes.

Um registro poderá conter:

```text
UsuarioId
Acao
Entidade
EntidadeId
DataHora
ValorAnterior
ValorNovo
```

---

# 86. Rastreamento histórico

Operações comerciais concluídas deverão preservar seu contexto histórico.

Por exemplo, uma venda deverá armazenar o preço utilizado no momento da operação.

Se o produto mudar de preço no futuro, uma venda antiga não deverá mudar.

O mesmo princípio deverá ser considerado para outras informações relevantes.

---

# 87. Princípios fundamentais

O desenvolvimento do LMSys Market seguirá os seguintes princípios:

1. O Domain não depende da interface.

2. Regras críticas de negócio não ficam em Views.

3. O banco possuirá regras de integridade.

4. Operações críticas serão transacionais.

5. Dados históricos não serão destruídos arbitrariamente.

6. Permissões serão validadas pela aplicação e não apenas através da interface.

7. A interface possuirá um Design System consistente.

8. Cada módulo deverá terminar funcional.

9. O código deverá permanecer testável.

10. O sistema deverá permitir evolução sem reescrever todo o núcleo.

11. Abstrações serão criadas quando trouxerem benefício real.

12. Evitaremos complexidade arquitetural sem necessidade.

13. Decisões importantes serão documentadas.

14. A qualidade visual será tratada como parte do produto.

15. Desempenho do PDV será considerado prioridade.

---

# 88. Status da arquitetura

Esta arquitetura representa a base inicial do **LMSys Market**.

Ela não deve ser considerada imutável.

À medida que os módulos forem desenvolvidos, novas necessidades poderão exigir ajustes.

Alterações arquiteturais importantes deverão:

1. possuir justificativa;
2. ser documentadas;
3. ser testadas;
4. ser versionadas no Git;
5. preservar sempre que possível a compatibilidade com os módulos existentes.

---

# 89. Próximos documentos

Após esta definição arquitetural, os próximos documentos do projeto serão:

```text
docs/database/database-design.md

docs/modules/roadmap.md

docs/modules/00-foundation.md
```

O documento `database-design.md` definirá:

- entidades persistidas;
- tabelas;
- relacionamentos;
- chaves;
- tipos de dados;
- índices;
- constraints;
- estratégia de IDs;
- modelagem inicial do PostgreSQL.

O documento `roadmap.md` definirá a sequência oficial do desenvolvimento.

O documento `00-foundation.md` definirá detalhadamente o primeiro módulo funcional do LMSys Market.