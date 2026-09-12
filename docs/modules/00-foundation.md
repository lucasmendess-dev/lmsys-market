# LMSys Market
## Módulo 00 — Foundation

**Documento:** Especificação do Módulo  
**Módulo:** 00 — Foundation  
**Versão do módulo:** 0.1  
**Versão prevista do produto:** v0.1.0  
**Status:** PLANNED  
**Produto:** LMSys Market  
**Plataforma:** Windows Desktop  
**Tecnologias principais:** C# / .NET 10 / WPF / PostgreSQL / Entity Framework Core

---

# 1. Objetivo

O módulo **Foundation** será responsável por criar toda a fundação técnica, arquitetural e visual do LMSys Market.

Ao final deste módulo, o projeto deixará de ser apenas documentação e passará a existir como uma aplicação desktop funcional.

O objetivo principal é entregar o primeiro fluxo real do sistema:

```text
Inicialização
     ↓
Login
     ↓
Autenticação
     ↓
Dashboard
     ↓
Navegação
     ↓
Logout
```

A partir desta fundação, todos os próximos módulos serão adicionados sem reconstruir a estrutura principal da aplicação.

---

# 2. Resultado esperado

Ao concluir o módulo deverá ser possível:

```text
Executar LMSys.Market.Desktop
        ↓
Aplicação inicia
        ↓
Tela de Login aparece
        ↓
Usuário informa credenciais
        ↓
Sistema valida usuário
        ↓
Usuário autenticado
        ↓
MainWindow é aberta
        ↓
Dashboard aparece
        ↓
Menu lateral funciona
        ↓
Usuário navega pelas áreas disponíveis
        ↓
Usuário realiza logout
        ↓
Tela de Login é exibida novamente
```

---

# 3. Objetivos técnicos

Este módulo deverá estabelecer:

- Solution .NET;
- projetos da arquitetura;
- referências entre projetos;
- estrutura de pastas;
- padrões de nomenclatura;
- Domain inicial;
- Application inicial;
- Infrastructure inicial;
- aplicação WPF;
- padrão MVVM;
- injeção de dependência;
- PostgreSQL;
- Entity Framework Core;
- migrations;
- autenticação;
- usuários;
- perfis;
- permissões;
- empresa;
- loja;
- sessão do usuário;
- navegação;
- Design System inicial;
- tratamento de erros;
- logging;
- testes iniciais.

---

# 4. Fora do escopo

Este módulo não implementará ainda:

- produtos;
- categorias de produtos;
- estoque;
- fornecedores;
- compras;
- clientes;
- vendas;
- PDV;
- caixa operacional;
- promoções;
- financeiro;
- inventário;
- perdas;
- relatórios completos;
- fiscal;
- TEF;
- balanças;
- impressoras.

Esses recursos pertencem aos módulos seguintes.

---

# 5. Estrutura da Solution

A solução será chamada:

```text
LMSys.Market.sln
```

Estrutura:

```text
lmsys-market/
│
├── docs/
│
├── src/
│   │
│   ├── LMSys.Market.Domain/
│   │
│   ├── LMSys.Market.Application/
│   │
│   ├── LMSys.Market.Infrastructure/
│   │
│   └── LMSys.Market.Desktop/
│
├── tests/
│   │
│   ├── LMSys.Market.Domain.Tests/
│   │
│   ├── LMSys.Market.Application.Tests/
│   │
│   └── LMSys.Market.Infrastructure.Tests/
│
├── LMSys.Market.sln
├── .gitignore
└── README.md
```

---

# 6. Projetos

Serão criados inicialmente:

```text
LMSys.Market.Domain
LMSys.Market.Application
LMSys.Market.Infrastructure
LMSys.Market.Desktop
```

Testes:

```text
LMSys.Market.Domain.Tests
LMSys.Market.Application.Tests
LMSys.Market.Infrastructure.Tests
```

---

# 7. Dependências entre projetos

As referências deverão respeitar:

```text
Domain
  ↑
Application
  ↑
  ├──────── Infrastructure
  │
  └──────── Desktop
```

Configuração:

```text
LMSys.Market.Application
    → LMSys.Market.Domain
```

```text
LMSys.Market.Infrastructure
    → LMSys.Market.Application
    → LMSys.Market.Domain
```

```text
LMSys.Market.Desktop
    → LMSys.Market.Application
    → LMSys.Market.Infrastructure
```

Testes:

```text
LMSys.Market.Domain.Tests
    → LMSys.Market.Domain
```

```text
LMSys.Market.Application.Tests
    → LMSys.Market.Application
    → LMSys.Market.Domain
```

```text
LMSys.Market.Infrastructure.Tests
    → LMSys.Market.Infrastructure
```

---

# 8. Domain

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

O Foundation utilizará inicialmente entidades relacionadas a:

```text
Company
Store
User
Role
Permission
```

---

# 9. Entidade Company

Representa a empresa proprietária da operação.

Propriedades iniciais:

```text
Id
LegalName
TradeName
Document
StateRegistration
Phone
Email
Address
City
State
ZipCode
IsActive
CreatedAt
UpdatedAt
```

---

# 10. Entidade Store

Representa uma loja ou filial.

Mesmo que a primeira versão utilize apenas uma loja, esta entidade existirá desde o início.

Propriedades:

```text
Id
CompanyId
Code
Name
Document
Phone
Email
Address
City
State
ZipCode
IsActive
CreatedAt
UpdatedAt
```

Relacionamento:

```text
Company
   │
   └──── Store
```

---

# 11. Entidade User

Representa um usuário do LMSys Market.

Propriedades:

```text
Id
Name
Username
Email
PasswordHash
RoleId
IsActive
LastLoginAt
CreatedAt
UpdatedAt
```

O usuário não armazenará senha em texto puro.

---

# 12. Entidade Role

Representa um perfil de acesso.

Exemplos:

```text
Administrator
Manager
Cashier
StockClerk
Buyer
Financial
```

Propriedades:

```text
Id
Name
Description
IsActive
CreatedAt
UpdatedAt
```

---

# 13. Entidade Permission

Representa uma permissão disponível no sistema.

Exemplos:

```text
dashboard.view

products.view
products.create
products.edit

inventory.view
inventory.adjust

sales.view
sales.cancel

cash.open
cash.withdraw
cash.close

users.view
users.manage

settings.view
settings.manage
```

Propriedades:

```text
Id
Code
Name
Description
CreatedAt
```

---

# 14. Relacionamento RolePermission

Um perfil poderá possuir diversas permissões.

Uma permissão poderá estar associada a diversos perfis.

Relacionamento:

```text
Role
  N
  │
  │
  N
Permission
```

Tabela intermediária:

```text
role_permissions
```

---

# 15. Relacionamento UserStore

Um usuário poderá futuramente possuir acesso a mais de uma loja.

Tabela:

```text
user_stores
```

Relacionamento:

```text
User
 N
 │
 │
 N
Store
```

Na primeira versão, normalmente cada usuário estará relacionado à loja principal.

---

# 16. Application

Estrutura inicial:

```text
LMSys.Market.Application/
│
├── Authentication/
├── Users/
├── Roles/
├── Stores/
├── DTOs/
├── Interfaces/
├── Services/
├── Validators/
└── Common/
```

---

# 17. Casos de uso iniciais

O Foundation deverá possuir casos de uso equivalentes a:

```text
AuthenticateUser

GetCurrentUser

CreateInitialAdministrator

GetUserPermissions

GetStoresForUser

Logout
```

Nem todos precisarão necessariamente existir como classes com exatamente esses nomes.

A estrutura definitiva será definida durante a implementação.

---

# 18. Autenticação

A autenticação será baseada inicialmente em:

```text
Username ou Email
+
Password
```

Fluxo:

```text
Usuário informa credenciais
        ↓
Application recebe solicitação
        ↓
Usuário é localizado
        ↓
Sistema verifica se está ativo
        ↓
Hash da senha é validado
        ↓
Permissões são carregadas
        ↓
Sessão é criada
```

---

# 19. Validação da senha

O sistema nunca deverá comparar senhas armazenadas em texto puro.

Será utilizado um algoritmo seguro de hash de senha.

A implementação deverá fornecer operações semelhantes a:

```text
HashPassword
VerifyPassword
```

O algoritmo definitivo será escolhido durante a implementação.

---

# 20. Sessão do usuário

Após autenticação, será criada uma sessão em memória.

Informações previstas:

```text
UserId
Name
Username
RoleId
RoleName
StoreId
StoreName
Permissions
```

A sessão permanecerá ativa enquanto o usuário estiver utilizando o aplicativo.

---

# 21. Current User

A aplicação deverá possuir um serviço responsável por fornecer informações sobre o usuário atualmente autenticado.

Interface conceitual:

```text
ICurrentUserService
```

Ele poderá fornecer:

```text
UserId
Name
Username
Role
Store
Permissions
IsAuthenticated
```

---

# 22. Autorização

A aplicação deverá possuir mecanismo para verificar permissões.

Exemplo conceitual:

```text
UserHasPermission("products.create")
```

A verificação não poderá existir apenas visualmente.

Esconder um botão não será considerado segurança suficiente.

---

# 23. Infrastructure

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
├── Authentication/
├── Services/
├── Logging/
└── DependencyInjection/
```

---

# 24. PostgreSQL

O banco utilizado será:

```text
PostgreSQL
```

No ambiente de desenvolvimento utilizaremos um banco semelhante a:

```text
lmsys_market_dev
```

---

# 25. Entity Framework Core

O projeto Infrastructure utilizará:

```text
Entity Framework Core
```

Provider:

```text
Npgsql.EntityFrameworkCore.PostgreSQL
```

---

# 26. DbContext

Será criado:

```text
LMSysMarketDbContext
```

Inicialmente contendo conjuntos relacionados a:

```text
Companies
Stores
Users
Roles
Permissions
RolePermissions
UserStores
```

---

# 27. Configurations

Cada entidade possuirá configuração separada quando apropriado.

Estrutura:

```text
Data/
└── Configurations/
    ├── CompanyConfiguration.cs
    ├── StoreConfiguration.cs
    ├── UserConfiguration.cs
    ├── RoleConfiguration.cs
    ├── PermissionConfiguration.cs
    ├── RolePermissionConfiguration.cs
    └── UserStoreConfiguration.cs
```

---

# 28. Primeira migration

A primeira migration deverá representar a fundação.

Nome previsto:

```text
InitialFoundation
```

Ela deverá criar:

```text
companies
stores
users
roles
permissions
role_permissions
user_stores
```

---

# 29. Seed inicial

O Foundation deverá possuir dados mínimos para permitir a primeira execução.

Seed previsto:

```text
Empresa inicial
Loja principal
Perfil Administrator
Permissões iniciais
Usuário administrador
```

Também poderão ser criados perfis básicos:

```text
Manager
Cashier
StockClerk
Buyer
Financial
```

---

# 30. Primeiro administrador

Precisaremos de uma estratégia segura para criação do primeiro administrador.

Durante o desenvolvimento, o seed poderá criar uma conta administrativa inicial.

Entretanto:

- a senha nunca ficará em texto puro no banco;
- não deverá existir senha administrativa definitiva escrita no código de produção;
- futuramente será possível implementar um fluxo de primeira configuração.

---

# 31. Repositories iniciais

Poderão ser necessários:

```text
IUserRepository
IRoleRepository
IStoreRepository
```

Implementações:

```text
UserRepository
RoleRepository
StoreRepository
```

Repositories somente serão criados quando trouxerem valor ao caso de uso.

---

# 32. Unit of Work

Será avaliada a criação de:

```text
IUnitOfWork
```

com operações equivalentes a:

```text
SaveChangesAsync
BeginTransactionAsync
CommitAsync
RollbackAsync
```

A abstração deverá permanecer simples.

---

# 33. Desktop

Estrutura inicial:

```text
LMSys.Market.Desktop/
│
├── Views/
│
├── ViewModels/
│
├── Controls/
│
├── Components/
│
├── Styles/
│
├── Resources/
│
├── Themes/
│
├── Converters/
│
├── Behaviors/
│
├── Services/
│
├── Navigation/
│
├── Assets/
│
├── DependencyInjection/
│
├── App.xaml
└── App.xaml.cs
```

---

# 34. Telas do Foundation

Inicialmente serão criadas:

```text
SplashView

LoginView

MainWindow

DashboardView
```

Poderemos também criar componentes ou views para:

```text
Sidebar
Header
UserMenu
```

---

# 35. Splash Screen

A aplicação poderá iniciar com uma tela curta de carregamento.

Objetivo:

```text
Inicializar configurações
        ↓
Inicializar serviços
        ↓
Verificar banco
        ↓
Carregar recursos
        ↓
Abrir Login
```

A Splash Screen não deverá atrasar artificialmente a abertura.

Se a inicialização for rápida, sua exibição também será rápida.

---

# 36. Login

A tela de Login deverá possuir aparência profissional.

Estrutura conceitual:

```text
┌───────────────────────────────────────────────────────────────┐
│                                                               │
│                       LMSys Market                            │
│                                                               │
│                  Gestão para supermercados                    │
│                                                               │
│                ┌───────────────────────────┐                  │
│                │ Usuário                   │                  │
│                │ [_______________________] │                  │
│                │                           │                  │
│                │ Senha                     │                  │
│                │ [_______________________] │                  │
│                │                           │                  │
│                │      ENTRAR               │                  │
│                └───────────────────────────┘                  │
│                                                               │
└───────────────────────────────────────────────────────────────┘
```

---

# 37. LoginViewModel

Deverá controlar:

```text
Username
Password
IsLoading
ErrorMessage
```

Comando:

```text
LoginCommand
```

Fluxo:

```text
LoginCommand
    ↓
AuthenticationService
    ↓
Resultado
```

Se sucesso:

```text
Abrir MainWindow
```

Se falha:

```text
Exibir erro
```

---

# 38. Estados do Login

A interface deverá tratar estados como:

```text
Normal

Carregando

Credenciais inválidas

Usuário inativo

Falha de conexão

Erro inesperado
```

Durante autenticação, o botão deverá impedir múltiplas solicitações simultâneas.

---

# 39. MainWindow

Após login, será exibida a janela principal.

Estrutura:

```text
┌───────────────────────────────────────────────────────────────┐
│ LMSys Market                             Lucas Mendes      ▼  │
├────────────────┬──────────────────────────────────────────────┤
│                │                                              │
│ Dashboard      │                                              │
│                │                                              │
│ PDV            │               Content Area                   │
│                │                                              │
│ Produtos       │                                              │
│                │                                              │
│ Estoque        │                                              │
│                │                                              │
│ Compras        │                                              │
│                │                                              │
│ Clientes       │                                              │
│                │                                              │
│ Financeiro     │                                              │
│                │                                              │
│ Relatórios     │                                              │
│                │                                              │
│ Usuários       │                                              │
│                │                                              │
│ Configurações  │                                              │
│                │                                              │
└────────────────┴──────────────────────────────────────────────┘
```

---

# 40. Menu lateral

O menu inicial apresentará:

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

Configurações
```

No Foundation, apenas:

```text
Dashboard
```

precisará estar completamente funcional.

Os demais itens poderão inicialmente indicar:

```text
Módulo ainda não disponível.
```

ou permanecer desabilitados.

Conforme cada módulo for desenvolvido, o menu correspondente será ativado.

---

# 41. Permissões no menu

Itens poderão ser exibidos conforme as permissões.

Exemplo:

```text
financial.view
```

Se o usuário não possuir esta permissão, o menu Financeiro poderá não ser apresentado.

Entretanto, isso não substituirá a autorização no nível da Application.

---

# 42. Header

O cabeçalho poderá apresentar:

```text
Nome da loja

Nome do usuário

Perfil

Notificações

Menu do usuário
```

Menu do usuário:

```text
Meu Perfil

Trocar Loja
Futuramente

Sair
```

Inicialmente será necessário:

```text
Sair
```

---

# 43. Dashboard inicial

Como ainda não teremos vendas, produtos ou estoque, o Dashboard inicial terá conteúdo básico.

Exemplo:

```text
Bem-vindo ao LMSys Market

Lucas Mendes

Loja:
Loja Principal

Sistema:
Online

Banco:
Conectado

Versão:
0.1.0
```

Poderão existir cards placeholders:

```text
Vendas hoje
R$ 0,00

Produtos
0

Estoque baixo
0

Caixas abertos
0
```

Esses indicadores serão conectados aos dados reais nos módulos futuros.

---

# 44. Navegação

Será criado um mecanismo centralizado de navegação.

Interface conceitual:

```text
INavigationService
```

Possíveis operações:

```text
NavigateTo<TViewModel>()

GoBack()

Logout()
```

A MainWindow possuirá uma área de conteúdo dinâmica.

---

# 45. MVVM

Nenhuma regra crítica ficará diretamente nas Views.

Exemplo:

```text
LoginView
     ↓
LoginViewModel
     ↓
AuthenticationService
```

Outro exemplo:

```text
DashboardView
     ↓
DashboardViewModel
```

---

# 46. BaseViewModel

Poderemos criar uma classe base:

```text
ViewModelBase
```

Responsável por mecanismos comuns, como:

```text
INotifyPropertyChanged
```

Ela deverá permanecer simples.

---

# 47. Commands

Será utilizado padrão de comandos para ações de interface.

Poderemos criar:

```text
RelayCommand
AsyncRelayCommand
```

ou utilizar biblioteca consolidada caso decidamos adotá-la.

A decisão será registrada durante a implementação.

---

# 48. CommunityToolkit.Mvvm

Será avaliada a utilização de:

```text
CommunityToolkit.Mvvm
```

Ela poderá simplificar:

- ObservableObject;
- RelayCommand;
- AsyncRelayCommand;
- propriedades observáveis;
- mensageria.

Se utilizada, deverá substituir código repetitivo sem comprometer a compreensão da arquitetura.

---

# 49. Injeção de dependência

Utilizaremos o sistema padrão de DI do .NET.

Biblioteca:

```text
Microsoft.Extensions.DependencyInjection
```

A inicialização registrará:

```text
DbContext

Repositories

Application Services

Authentication

Current User

Navigation

ViewModels

Views
```

---

# 50. Configuration

Utilizaremos configuração centralizada.

Exemplo:

```text
appsettings.json
```

Poderá conter:

```text
ConnectionStrings

Logging

Application Settings
```

Informações sensíveis não deverão ser commitadas de maneira insegura.

---

# 51. Connection String

A conexão com o PostgreSQL seguirá conceito semelhante a:

```text
Host=localhost;
Port=5432;
Database=lmsys_market_dev;
Username=...
Password=...
```

A credencial definitiva não deverá ficar exposta em documentação pública.

---

# 52. Configuração de desenvolvimento

O ambiente de desenvolvimento poderá utilizar:

```text
appsettings.Development.json
```

Caso contenha credenciais locais, deverá ser tratado adequadamente no `.gitignore`.

---

# 53. Logging

Utilizaremos a infraestrutura de logging do .NET.

Inicialmente poderemos registrar:

```text
Inicialização

Login bem-sucedido

Login inválido

Falha de banco

Exceções

Encerramento
```

Dados sensíveis, como senha, nunca deverão aparecer nos logs.

---

# 54. Tratamento global de exceções

A aplicação deverá possuir tratamento para falhas inesperadas.

O objetivo será:

```text
Capturar
 ↓
Registrar log
 ↓
Exibir mensagem amigável
 ↓
Evitar encerramento abrupto quando possível
```

---

# 55. Mensagem técnica x mensagem ao usuário

Exemplo de log:

```text
NpgsqlException:
connection refused...
```

Mensagem para o usuário:

```text
Não foi possível conectar ao banco de dados.

Verifique a conexão com o servidor e tente novamente.
```

---

# 56. Design System

O Foundation será responsável por criar a base visual reutilizável.

Inicialmente serão definidos:

```text
Colors

Typography

Buttons

Inputs

Cards

DataGrid

Sidebar

Header

Dialogs

Notifications
```

Nem todos precisarão estar completos.

A fundação deverá permitir evolução consistente.

---

# 57. Paleta

A paleta oficial será definida durante a implementação visual.

Deverá possuir pelo menos:

```text
Primary

PrimaryHover

Secondary

Background

Surface

Border

TextPrimary

TextSecondary

Success

Warning

Danger

Information
```

---

# 58. Tipografia

Será definida uma hierarquia.

Exemplo:

```text
Display

Heading1

Heading2

Heading3

Body

BodySmall

Caption
```

O objetivo será manter consistência entre todas as telas.

---

# 59. Botões

Estilos iniciais:

```text
PrimaryButton

SecondaryButton

DangerButton

GhostButton

IconButton
```

Estados:

```text
Normal

Hover

Pressed

Disabled

Loading
```

---

# 60. Inputs

Componentes iniciais:

```text
TextInput

PasswordInput

SearchInput
```

Estados:

```text
Normal

Focused

Disabled

Error
```

---

# 61. Cards

Cards serão utilizados para:

```text
Indicadores

Informações

Agrupamento de conteúdo
```

Um componente visual consistente evitará repetição de estilos.

---

# 62. Ícones

O sistema deverá utilizar um conjunto consistente de ícones.

Não deverão ser misturados diversos estilos visuais incompatíveis.

A biblioteca definitiva será escolhida durante a criação da interface.

---

# 63. Responsividade Desktop

Embora seja desktop, a interface deverá suportar diferentes resoluções.

Resolução de referência inicial:

```text
1920 x 1080
```

Também deverá permanecer utilizável em:

```text
1366 x 768
```

quando possível.

---

# 64. Janela

A MainWindow deverá possuir tamanho mínimo adequado.

Não deverá ser possível reduzir a janela a um tamanho que destrua completamente o layout.

---

# 65. Performance de inicialização

O LMSys Market deverá abrir em tempo adequado.

Não serão carregados dados desnecessários durante a inicialização.

Fluxo ideal:

```text
Iniciar aplicação
 ↓
Configurar serviços
 ↓
Validar infraestrutura essencial
 ↓
Abrir Login
```

---

# 66. Banco indisponível

Se o PostgreSQL estiver indisponível durante o login, o usuário deverá receber uma mensagem apropriada.

Exemplo:

```text
Não foi possível conectar ao servidor do LMSys Market.

Verifique a conexão e tente novamente.
```

O aplicativo não deverá apresentar uma exceção técnica diretamente.

---

# 67. Testes de Domain

No Foundation poderemos possuir testes como:

```text
Usuário inativo não pode ser considerado habilitado.

Role deve possuir nome válido.

Permission deve possuir código válido.
```

O objetivo não será criar testes artificiais.

Somente comportamentos reais deverão ser testados.

---

# 68. Testes de Application

Testes importantes:

```text
Login com usuário válido funciona.

Login com senha incorreta falha.

Login de usuário inativo falha.

Login de usuário inexistente falha.
```

Também deverão ser verificadas permissões quando aplicável.

---

# 69. Testes de Infrastructure

Poderão testar:

```text
Mapeamento de User

Mapeamento de Role

Relacionamento RolePermission

Relacionamento UserStore

Persistência

Consultas de usuário
```

---

# 70. Teste manual 01 — Inicialização

Procedimento:

```text
1. Executar LMSys.Market.Desktop.

2. Verificar abertura da aplicação.

3. Confirmar exibição do Login.

4. Confirmar que não existem erros visíveis.
```

Resultado esperado:

```text
PASS
```

---

# 71. Teste manual 02 — Login válido

Procedimento:

```text
1. Informar usuário administrador.

2. Informar senha correta.

3. Clicar em Entrar.
```

Resultado esperado:

```text
MainWindow aberta.

Dashboard visível.

Usuário exibido no cabeçalho.
```

---

# 72. Teste manual 03 — Login inválido

Procedimento:

```text
1. Informar usuário válido.

2. Informar senha incorreta.

3. Clicar em Entrar.
```

Resultado esperado:

```text
Login negado.

Mensagem amigável apresentada.

MainWindow não aberta.
```

---

# 73. Teste manual 04 — Usuário inexistente

Resultado esperado:

```text
Acesso negado.
```

A mensagem não deverá revelar desnecessariamente se o usuário ou a senha foi o elemento incorreto.

Mensagem sugerida:

```text
Usuário ou senha inválidos.
```

---

# 74. Teste manual 05 — Logout

Procedimento:

```text
1. Realizar login.

2. Abrir menu do usuário.

3. Selecionar Sair.
```

Resultado esperado:

```text
Sessão encerrada.

MainWindow fechada.

Login exibido.
```

---

# 75. Teste manual 06 — Banco indisponível

Procedimento:

```text
1. Interromper PostgreSQL.

2. Executar tentativa de login.
```

Resultado esperado:

```text
Aplicação permanece estável.

Mensagem de conexão é exibida.

Erro técnico é registrado em log.
```

---

# 76. Teste manual 07 — Reinício

Procedimento:

```text
1. Abrir aplicação.

2. Realizar login.

3. Fechar aplicação.

4. Abrir novamente.
```

Na primeira versão, não precisaremos manter login automaticamente.

Resultado esperado:

```text
Login apresentado novamente.
```

---

# 77. Requisitos relacionados

Este módulo implementará principalmente requisitos relacionados a:

```text
RF001 — Autenticar usuário

RF002 — Encerrar sessão

RF003 — Bloquear usuário inativo

RF004 — Identificar usuário autenticado

RF005 — Registrar acesso

RF006 — Cadastro de usuário
Parcialmente

RF009 — Perfis

RF010 — Permissões
```

E requisitos não funcionais relacionados a:

```text
RNF001 — Aplicação Desktop

RNF002 — Tecnologia

RNF003 — Aparência profissional

RNF004 — Design System

RNF005 — Consistência visual

RNF008 — Separação de responsabilidades

RNF009 — Baixo acoplamento

RNF010 — MVVM

RNF011 — Injeção de dependência

RNF012 — PostgreSQL

RNF013 — Entity Framework Core

RNF014 — Migrations

RNF016 — Senhas protegidas

RNF017 — Autorização

RNF030 — Tratamento de erros

RNF032 — Logging

RNF040 — Git

RNF041 — GitHub
```

---

# 78. Ordem de implementação

O Foundation será desenvolvido em etapas pequenas.

A sequência prevista será:

```text
Etapa 00.1
Solution e projetos

Etapa 00.2
Referências e arquitetura

Etapa 00.3
Pacotes NuGet

Etapa 00.4
Domain inicial

Etapa 00.5
PostgreSQL + EF Core

Etapa 00.6
Entidades Foundation

Etapa 00.7
DbContext e mappings

Etapa 00.8
Migration InitialFoundation

Etapa 00.9
Seed inicial

Etapa 00.10
Repositories

Etapa 00.11
Authentication Service

Etapa 00.12
Current User

Etapa 00.13
Estrutura WPF/MVVM

Etapa 00.14
Design System

Etapa 00.15
Login

Etapa 00.16
MainWindow

Etapa 00.17
Navegação

Etapa 00.18
Dashboard

Etapa 00.19
Logout

Etapa 00.20
Logging e tratamento de erros

Etapa 00.21
Testes

Etapa 00.22
Documentação

Etapa 00.23
Commit e integração
```

---

# 79. Etapa 00.1 — Solution

Será criado:

```text
LMSys.Market.sln
```

E os sete projetos iniciais.

Resultado:

```text
dotnet build
```

deverá funcionar.

---

# 80. Etapa 00.2 — Arquitetura

As referências entre projetos serão adicionadas.

Será validado que:

```text
Domain
```

não possui referência para:

```text
Application
Infrastructure
Desktop
```

---

# 81. Etapa 00.3 — Pacotes

Os pacotes serão instalados apenas nos projetos necessários.

Exemplos previstos:

```text
Microsoft.EntityFrameworkCore

Microsoft.EntityFrameworkCore.Design

Npgsql.EntityFrameworkCore.PostgreSQL

Microsoft.Extensions.DependencyInjection

Microsoft.Extensions.Hosting

Microsoft.Extensions.Configuration
```

Outros serão adicionados conforme necessidade.

---

# 82. Etapa 00.4 — Domain

Criação das primeiras entidades e regras.

Resultado:

```text
Domain compila de forma independente.
```

---

# 83. Etapa 00.5 — PostgreSQL

Será criada a conexão com o ambiente de desenvolvimento.

Banco previsto:

```text
lmsys_market_dev
```

Resultado:

```text
Aplicação consegue acessar PostgreSQL.
```

---

# 84. Etapa 00.6 — Entidades

Serão implementadas:

```text
Company
Store
User
Role
Permission
```

e relacionamentos necessários.

---

# 85. Etapa 00.7 — DbContext

Será criado:

```text
LMSysMarketDbContext
```

com seus mappings.

---

# 86. Etapa 00.8 — Migration

Será gerada:

```text
InitialFoundation
```

Resultado esperado:

```text
Database update concluído.
```

---

# 87. Etapa 00.9 — Seed

Serão criados dados mínimos.

Exemplo:

```text
LMSys

Loja Principal

Administrator

Usuário administrador
```

---

# 88. Etapa 00.10 — Repositories

Será implementado inicialmente o necessário para autenticação.

Prioridade:

```text
IUserRepository

UserRepository
```

Outros somente se necessários.

---

# 89. Etapa 00.11 — Authentication

Será implementado:

```text
IAuthenticationService

AuthenticationService
```

Fluxo:

```text
Username
Password
 ↓
Authenticate
 ↓
User
Permissions
Store
```

---

# 90. Etapa 00.12 — Current User

Será criada estrutura para armazenar o usuário autenticado.

Resultado:

```text
Qualquer ViewModel autorizado poderá consultar
informações da sessão atual.
```

---

# 91. Etapa 00.13 — WPF

Será criada a estrutura visual inicial.

Primeiro objetivo:

```text
Abrir uma janela WPF.
```

Depois:

```text
Integrar MVVM.
```

---

# 92. Etapa 00.14 — Design System

Criação dos primeiros ResourceDictionaries.

Exemplo:

```text
Colors.xaml

Typography.xaml

Buttons.xaml

Inputs.xaml
```

Resultado:

```text
Login já deverá utilizar o padrão visual oficial.
```

---

# 93. Etapa 00.15 — Login

Implementar:

```text
LoginView

LoginViewModel
```

E conectar com:

```text
AuthenticationService
```

---

# 94. Etapa 00.16 — MainWindow

Implementar:

```text
MainWindow

MainViewModel
```

Com:

```text
Sidebar
Header
Content
```

---

# 95. Etapa 00.17 — Navigation

Implementar serviço de navegação.

O clique em:

```text
Dashboard
```

deverá exibir:

```text
DashboardView
```

na área principal.

---

# 96. Etapa 00.18 — Dashboard

Implementar:

```text
DashboardView

DashboardViewModel
```

Inicialmente com dados básicos e placeholders.

---

# 97. Etapa 00.19 — Logout

Logout deverá:

```text
Limpar sessão
 ↓
Fechar MainWindow
 ↓
Abrir Login
```

---

# 98. Etapa 00.20 — Erros e Logging

Adicionar:

```text
tratamento global;

logs;

mensagens amigáveis;

tratamento de falha de banco.
```

---

# 99. Etapa 00.21 — Testes

Executar:

```text
dotnet test
```

Todos os testes deverão passar antes da conclusão.

---

# 100. Etapa 00.22 — Documentação

Atualizar este documento com:

```text
Arquivos criados

Decisões tomadas

Problemas encontrados

Alterações de arquitetura

Status
```

---

# 101. Etapa 00.23 — Git

Ao finalizar:

```text
git status

git add .

git commit
```

Mensagem sugerida:

```text
feat: implement foundation module
```

Depois:

```text
git push
```

A integração à `develop` será feita após validação.

---

# 102. Branch do módulo

Branch prevista:

```text
feature/foundation
```

Fluxo:

```text
develop
   │
   └──── feature/foundation
                 │
                 │ desenvolvimento
                 │
                 ▼
              testes
                 │
                 ▼
              develop
```

---

# 103. Critérios de aceitação

O Foundation somente poderá ser marcado como concluído quando todos os critérios abaixo forem atendidos.

```text
[ ] Solution criada

[ ] Todos os projetos compilam

[ ] Dependências respeitam arquitetura

[ ] PostgreSQL conectado

[ ] DbContext funcionando

[ ] Migration funcionando

[ ] Seed funcionando

[ ] Empresa criada

[ ] Loja criada

[ ] Usuário administrador criado

[ ] Senha protegida

[ ] Login funcionando

[ ] Login inválido tratado

[ ] Usuário inativo impedido

[ ] Sessão funcionando

[ ] MainWindow funcionando

[ ] Sidebar funcionando

[ ] Dashboard funcionando

[ ] Nome do usuário exibido

[ ] Nome da loja exibido

[ ] Logout funcionando

[ ] Tratamento de erro funcionando

[ ] Logging funcionando

[ ] Interface profissional

[ ] Testes passando

[ ] Documentação atualizada

[ ] Código versionado
```

---

# 104. Definição de pronto

O Módulo Foundation será considerado:

```text
COMPLETED
```

somente quando o seguinte fluxo funcionar integralmente:

```text
Usuário abre LMSys Market
        ↓
Login aparece
        ↓
Usuário informa credenciais
        ↓
Sistema autentica
        ↓
Dashboard é exibido
        ↓
Sidebar funciona
        ↓
Usuário identificado
        ↓
Loja identificada
        ↓
Usuário realiza logout
        ↓
Login reaparece
```

Sem erros críticos conhecidos.

---

# 105. Versão

Ao finalizar o módulo, a versão será:

```text
LMSys Market
v0.1.0
```

Codename:

```text
Foundation
```

---

# 106. Próximo módulo

Após Foundation:

```text
01 — Products
```

Objetivo:

```text
Cadastro completo de produtos.
```

Fluxo seguinte:

```text
Foundation
   ↓
Login
   ↓
Dashboard
   ↓
Produtos
   ↓
Cadastro
   ↓
Pesquisa
   ↓
Edição
```

---

# 107. Status atual

```text
MODULE: 00 Foundation

STATUS: PLANNED
```

Próxima ação:

```text
Criar branch:

feature/foundation
```

Depois:

```text
Criar LMSys.Market.sln
```

E iniciar a:

```text
Etapa 00.1 — Solution e Projetos
```

---

# 108. Histórico

## Versão 0.1

Criação inicial da especificação do módulo Foundation.

Definidos:

- objetivos;
- arquitetura;
- entidades iniciais;
- banco;
- autenticação;
- interface;
- navegação;
- testes;
- critérios de aceitação;
- ordem de implementação.