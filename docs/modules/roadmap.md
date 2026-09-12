# LMSys Market
## Roadmap de Desenvolvimento

**Documento:** Roadmap do Projeto  
**Versão:** 0.1  
**Status:** Planejamento inicial  
**Produto:** LMSys Market  
**Plataforma:** Windows Desktop  
**Tecnologias principais:** C# / .NET 10 / WPF / PostgreSQL / Entity Framework Core

---

# 1. Objetivo

Este documento define a ordem oficial de desenvolvimento do **LMSys Market**.

O projeto será desenvolvido de maneira incremental e modular.

A regra principal será:

> Nenhum módulo deverá ser desenvolvido de forma isolada por longos períodos sem que seja possível executar e testar o sistema.

Ao final de cada módulo, o LMSys Market deverá permanecer:

- compilável;
- executável;
- funcional;
- integrado;
- testável;
- documentado;
- versionado no Git.

---

# 2. Estratégia geral

O desenvolvimento seguirá o fluxo:

```text
Planejamento
    ↓
Modelagem
    ↓
Implementação
    ↓
Interface
    ↓
Integração
    ↓
Testes
    ↓
Validação manual
    ↓
Documentação
    ↓
Commit
    ↓
Próximo módulo
```

Cada módulo deverá agregar novas funcionalidades ao sistema existente.

---

# 3. Branches

A estratégia inicial utilizará:

```text
main
develop
feature/*
fix/*
```

## main

Representará versões estáveis do projeto.

Não deverá receber desenvolvimento direto de funcionalidades.

---

## develop

Será a principal branch de integração durante o desenvolvimento.

Os módulos concluídos serão integrados nela.

---

## feature/*

Cada funcionalidade ou módulo poderá possuir uma branch própria.

Exemplos:

```text
feature/foundation
feature/authentication
feature/products
feature/inventory
feature/purchases
feature/pos
feature/cash-register
feature/customers
feature/financial
```

---

## fix/*

Utilizada para correções.

Exemplo:

```text
fix/product-search
fix/inventory-calculation
fix/login-validation
```

---

# 4. Commits

O projeto utilizará mensagens claras e padronizadas.

Exemplos:

```text
feat: adiciona autenticação de usuários

feat: implementa cadastro de produtos

fix: corrige cálculo de saldo de estoque

docs: atualiza requisitos do módulo de vendas

refactor: reorganiza serviço de autenticação

test: adiciona testes de finalização de venda

chore: configura estrutura da solução
```

---

# 5. Roadmap geral

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
12 - Production Readiness
```

---

# 6. Módulo 00 — Foundation

## Objetivo

Criar a fundação técnica e visual do LMSys Market.

O sistema deverá terminar este módulo como uma aplicação desktop real e executável.

---

## Escopo

O módulo deverá contemplar:

- criação da solution;
- criação dos projetos;
- referências entre projetos;
- estrutura inicial da arquitetura;
- configuração do WPF;
- estrutura MVVM;
- injeção de dependência;
- configuração do PostgreSQL;
- configuração do Entity Framework Core;
- DbContext;
- migrations iniciais;
- empresa;
- loja;
- usuários;
- perfis;
- permissões;
- autenticação;
- sessão do usuário;
- Design System inicial;
- tela de login;
- janela principal;
- menu lateral;
- cabeçalho;
- navegação;
- dashboard inicial;
- logout;
- tratamento inicial de erros;
- logging inicial.

---

## Banco inicial

Serão criadas inicialmente as tabelas necessárias para a fundação:

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

## Resultado esperado

Ao final deste módulo deverá ser possível:

```text
Abrir LMSys Market
        ↓
Visualizar Login
        ↓
Informar usuário e senha
        ↓
Autenticar
        ↓
Abrir MainWindow
        ↓
Visualizar menu lateral
        ↓
Visualizar Dashboard
        ↓
Visualizar usuário autenticado
        ↓
Realizar Logout
```

---

## Marco

```text
LMSys Market v0.1.0
Foundation
```

---

# 7. Módulo 01 — Products

## Objetivo

Implementar o cadastro e gerenciamento completo de produtos.

---

## Escopo

Será implementado:

- produtos;
- categorias;
- subcategorias;
- marcas;
- unidades de medida;
- códigos de barras;
- preço de venda;
- custo;
- estoque mínimo;
- estoque máximo;
- produto pesável;
- controle de lote;
- controle de validade;
- ativação;
- desativação;
- pesquisa;
- filtros;
- paginação;
- validações.

---

## Banco

Tabelas previstas:

```text
products
product_categories
brands
units
product_barcodes
product_price_history
```

---

## Interface

Telas previstas:

```text
Lista de Produtos

Cadastro de Produto

Categorias

Marcas

Unidades de Medida

Histórico de Preço
```

---

## Fluxo de teste

```text
Login
 ↓
Produtos
 ↓
Novo Produto
 ↓
Cadastrar categoria
 ↓
Selecionar unidade
 ↓
Cadastrar código de barras
 ↓
Informar preço
 ↓
Salvar
 ↓
Pesquisar produto
 ↓
Editar
 ↓
Desativar
```

---

## Critério de conclusão

Deverá ser possível realizar um CRUD completo de produtos sem acessar diretamente o banco.

---

## Marco

```text
LMSys Market v0.2.0
Products
```

---

# 8. Módulo 02 — Inventory

## Objetivo

Criar o controle completo de estoque.

---

## Escopo

Será implementado:

- saldo por produto;
- saldo por loja;
- entrada;
- saída;
- ajuste;
- histórico;
- estoque mínimo;
- alertas;
- controle de concorrência;
- lotes;
- validade;
- consulta de movimentações.

---

## Banco

Tabelas:

```text
inventory_balances
inventory_movements
inventory_batches
```

---

## Regras críticas

Toda alteração de estoque deverá gerar uma movimentação.

Não será permitido alterar diretamente:

```text
inventory_balances.quantity
```

sem uma operação de negócio correspondente.

---

## Fluxo de teste

```text
Produto cadastrado
 ↓
Entrada manual
 ↓
Saldo aumenta
 ↓
Saída manual
 ↓
Saldo diminui
 ↓
Consultar histórico
 ↓
Realizar ajuste
 ↓
Consultar novo saldo
```

---

## Marco

```text
LMSys Market v0.3.0
Inventory
```

---

# 9. Módulo 03 — Suppliers & Purchases

## Objetivo

Implementar fornecedores, pedidos de compra e recebimento de mercadorias.

---

## Escopo

Será implementado:

- cadastro de fornecedores;
- pesquisa;
- edição;
- desativação;
- pedidos de compra;
- itens do pedido;
- custos;
- descontos;
- status;
- aprovação;
- recebimento;
- recebimento parcial;
- lote;
- validade;
- entrada automática no estoque.

---

## Banco

Tabelas:

```text
suppliers
purchase_orders
purchase_order_items
purchase_receipts
purchase_receipt_items
```

---

## Fluxo principal

```text
Cadastrar fornecedor
 ↓
Criar pedido
 ↓
Adicionar produtos
 ↓
Confirmar pedido
 ↓
Receber mercadoria
 ↓
Confirmar recebimento
 ↓
Entrada automática no estoque
```

---

## Fluxo de teste

Antes:

```text
Arroz
Estoque = 10
```

Pedido:

```text
Quantidade = 100
```

Após recebimento:

```text
Estoque = 110
```

Também deverá existir uma movimentação:

```text
PURCHASE_ENTRY
+100
```

---

## Marco

```text
LMSys Market v0.4.0
Purchasing
```

---

# 10. Módulo 04 — POS

## Objetivo

Construir o ponto de venda do LMSys Market.

Este será um dos módulos mais importantes de todo o projeto.

---

## Escopo

Será implementado:

- interface específica de PDV;
- pesquisa por código;
- leitura de código de barras;
- pesquisa por descrição;
- carrinho;
- quantidade;
- produtos pesáveis;
- preço;
- subtotal;
- descontos;
- cancelamento de item;
- cliente opcional;
- pagamentos;
- pagamentos mistos;
- dinheiro;
- PIX;
- crédito;
- débito;
- cálculo de troco;
- conclusão da venda;
- atualização de estoque.

---

## Banco

Tabelas:

```text
sales
sale_items
sale_payments
payment_methods
```

---

## Dependências

Este módulo dependerá principalmente de:

```text
Products
Inventory
Foundation
```

---

## Interface

A tela deverá ser otimizada para:

- teclado;
- velocidade;
- poucos cliques;
- leitura imediata;
- operação contínua;
- visualização clara do total.

---

## Fluxo

```text
Operador abre PDV
 ↓
Digita / lê código
 ↓
Produto localizado
 ↓
Produto adicionado
 ↓
Outros produtos adicionados
 ↓
Operador informa pagamento
 ↓
Sistema valida total
 ↓
Venda finalizada
 ↓
Estoque baixado
 ↓
Venda registrada
```

---

## Teste crítico

Antes:

```text
Produto A
Estoque = 50
```

Venda:

```text
Quantidade = 3
```

Depois:

```text
Estoque = 47
```

Deverá existir:

```text
SALE_EXIT
-3
```

---

## Transação

A finalização deverá ocorrer de maneira atômica:

```text
BEGIN

Criar venda
Criar itens
Criar pagamentos
Atualizar estoque
Criar movimentações

COMMIT
```

Em caso de falha:

```text
ROLLBACK
```

---

## Marco

```text
LMSys Market v0.5.0
POS
```

---

# 11. Módulo 05 — Cash Register

## Objetivo

Completar o ciclo operacional de caixa.

---

## Escopo

Será implementado:

- terminais;
- caixas;
- abertura;
- valor inicial;
- sessão;
- suprimento;
- sangria;
- movimentações;
- vendas vinculadas à sessão;
- fechamento;
- valor esperado;
- valor informado;
- diferença;
- histórico.

---

## Banco

Tabelas:

```text
terminals
cash_registers
cash_sessions
cash_movements
```

---

## Fluxo

```text
Operador entra
 ↓
Seleciona caixa
 ↓
Abre caixa
 ↓
Informa valor inicial
 ↓
Realiza vendas
 ↓
Realiza sangria / suprimento
 ↓
Solicita fechamento
 ↓
Informa valor encontrado
 ↓
Sistema compara valores
 ↓
Caixa encerrado
```

---

## Regra

Nenhuma venda deverá ser vinculada a uma sessão fechada.

---

## Marco

```text
LMSys Market v0.6.0
Cash Register
```

---

# 12. Primeiro grande marco operacional

Ao terminar o Módulo 05 teremos o primeiro fluxo comercial completo.

O LMSys Market deverá conseguir executar:

```text
LOGIN
  ↓
PRODUTO
  ↓
FORNECEDOR
  ↓
PEDIDO DE COMPRA
  ↓
RECEBIMENTO
  ↓
ESTOQUE
  ↓
ABERTURA DE CAIXA
  ↓
VENDA
  ↓
PAGAMENTO
  ↓
BAIXA DO ESTOQUE
  ↓
MOVIMENTAÇÃO DO CAIXA
  ↓
FECHAMENTO DO CAIXA
```

Neste momento já teremos um sistema comercial funcional em sua essência.

---

# 13. Módulo 06 — Customers

## Objetivo

Adicionar gerenciamento de clientes.

---

## Escopo

Será implementado:

- cadastro;
- edição;
- pesquisa;
- CPF;
- contato;
- endereço;
- desativação;
- vínculo com vendas;
- histórico;
- total consumido;
- ticket médio do cliente.

---

## Banco

Tabela principal:

```text
customers
```

---

## Integração

As vendas poderão ser:

```text
Consumidor não identificado
```

ou:

```text
Cliente identificado
```

---

## Marco

```text
LMSys Market v0.7.0
Customers
```

---

# 14. Módulo 07 — Financial

## Objetivo

Adicionar gestão financeira administrativa.

---

## Escopo

Será implementado:

- categorias financeiras;
- contas a pagar;
- contas a receber;
- receitas;
- despesas;
- vencimentos;
- pagamentos;
- recebimentos;
- status;
- filtros;
- fluxo financeiro.

---

## Banco

Tabelas:

```text
financial_categories
accounts_payable
accounts_receivable
```

---

## Interface

Telas:

```text
Financeiro

Contas a Pagar

Contas a Receber

Receitas

Despesas

Fluxo de Caixa
```

---

## Marco

```text
LMSys Market v0.8.0
Financial
```

---

# 15. Módulo 08 — Promotions

## Objetivo

Implementar regras promocionais.

---

## Escopo

Inicialmente:

- promoção por preço;
- desconto percentual;
- promoção por quantidade;
- data inicial;
- data final;
- ativação;
- prioridade;
- aplicação automática no PDV.

---

## Banco

Tabelas:

```text
promotions
promotion_products
```

---

## Exemplos

```text
Coca-Cola 2L

Preço normal:
R$ 11,99

Preço promocional:
R$ 9,99
```

Outro exemplo:

```text
Leve 3 por R$ 10,00
```

---

## Regra crítica

O PDV deverá saber qual regra aplicar quando existirem promoções concorrentes.

---

## Marco

```text
LMSys Market v0.9.0
Promotions
```

---

# 16. Módulo 09 — Inventory & Losses

## Objetivo

Adicionar processos avançados de controle físico de estoque.

---

## Escopo

Será implementado:

- inventário;
- abertura do inventário;
- contagem;
- divergências;
- ajustes;
- perdas;
- vencimentos;
- quebra;
- avaria;
- furto;
- consumo interno;
- confirmação;
- histórico.

---

## Banco

Tabelas:

```text
inventory_counts
inventory_count_items
losses
loss_items
```

---

## Fluxo do inventário

```text
Criar inventário
 ↓
Capturar saldo do sistema
 ↓
Realizar contagem
 ↓
Comparar
 ↓
Mostrar divergências
 ↓
Confirmar
 ↓
Gerar ajustes
```

---

## Fluxo de perda

```text
Selecionar produto
 ↓
Informar quantidade
 ↓
Informar motivo
 ↓
Confirmar
 ↓
Baixar estoque
 ↓
Registrar movimentação
```

---

## Marco

```text
LMSys Market v0.10.0
Inventory Control
```

---

# 17. Módulo 10 — Dashboard & Reports

## Objetivo

Transformar os dados operacionais em informações gerenciais.

---

## Dashboard

Indicadores previstos:

```text
Faturamento do dia

Faturamento do mês

Quantidade de vendas

Ticket médio

Produtos vendidos

Produtos mais vendidos

Produtos com estoque baixo

Produtos próximos do vencimento

Perdas

Compras

Contas a pagar

Contas a receber
```

---

## Relatórios

Serão implementados relatórios de:

```text
Vendas

Produtos

Estoque

Movimentações

Compras

Fornecedores

Clientes

Caixas

Financeiro

Perdas

Margem
```

---

## Filtros

Relatórios deverão permitir filtros como:

```text
Período

Loja

Produto

Categoria

Fornecedor

Cliente

Operador

Status
```

---

## Exportação

Posteriormente poderemos implementar:

```text
PDF
Excel
CSV
```

de acordo com a necessidade.

---

## Marco

```text
LMSys Market v0.11.0
Analytics
```

---

# 18. Módulo 11 — Audit & Security

## Objetivo

Consolidar segurança e rastreabilidade.

---

## Escopo

Será implementado ou aprimorado:

- auditoria;
- histórico de ações;
- permissões detalhadas;
- autorização;
- políticas por perfil;
- controle de ações críticas;
- registros de alterações;
- logs;
- segurança de credenciais.

---

## Banco

Tabela principal:

```text
audit_logs
```

---

## Operações auditadas

Entre outras:

```text
Alteração de preço

Cancelamento de venda

Cancelamento de item

Ajuste de estoque

Sangria

Fechamento de caixa

Alteração de usuário

Alteração de perfil

Alteração de permissões

Inventário

Perda
```

---

## Marco

```text
LMSys Market v0.12.0
Security & Audit
```

---

# 19. Módulo 12 — Production Readiness

## Objetivo

Preparar o LMSys Market para utilização fora do ambiente de desenvolvimento.

---

## Escopo

Nesta fase serão avaliados:

- instalador;
- configuração inicial;
- banco;
- migrations;
- criação da empresa;
- criação da loja;
- primeiro administrador;
- logs;
- backups;
- tratamento de falhas;
- performance;
- segurança;
- configurações;
- documentação de instalação;
- testes completos.

---

## Instalação

A meta será permitir algo semelhante a:

```text
Instalar LMSys Market
 ↓
Configurar conexão com PostgreSQL
 ↓
Criar banco
 ↓
Executar migrations
 ↓
Cadastrar empresa
 ↓
Cadastrar loja
 ↓
Criar administrador
 ↓
Entrar no sistema
```

---

## Marco

```text
LMSys Market v1.0.0
```

Essa versão representará a primeira grande versão estável do produto.

---

# 20. Evoluções pós 1.0

Após a versão 1.0, o projeto poderá evoluir para módulos adicionais.

---

# 21. Fiscal

Possíveis funcionalidades:

```text
NFC-e
NF-e
Eventos fiscais
Cancelamentos
Contingência
Certificado digital
SEFAZ
```

Essa etapa exigirá análise específica das regras fiscais aplicáveis.

---

# 22. TEF

Integração futura com:

```text
Crédito
Débito
PIX
Adquirentes
Terminais
```

---

# 23. Balanças

Poderemos implementar:

```text
integração direta;
etiquetas de balança;
produtos pesáveis;
códigos de peso/preço.
```

---

# 24. Impressoras

Poderemos integrar:

```text
impressora térmica;
impressora de etiquetas;
impressão de relatórios.
```

---

# 25. Fidelidade

Possibilidades:

```text
Pontos

Cashback

Cupons

Descontos personalizados

Campanhas
```

---

# 26. Multi-loja

Uma evolução futura poderá permitir:

```text
Empresa
│
├── Loja 01
├── Loja 02
├── Loja 03
└── Loja 04
```

Com:

```text
estoque independente;
transferências;
relatórios consolidados;
usuários por loja;
preços por loja;
caixas por loja.
```

---

# 27. API

Futuramente poderá ser criado:

```text
LMSys.Market.Api
```

permitindo integrações com:

```text
Aplicativos

E-commerce

Delivery

Marketplaces

Integrações empresariais

Painéis web
```

---

# 28. Aplicativo móvel

Possíveis funcionalidades futuras:

```text
Consulta de estoque

Inventário

Recebimento

Dashboard

Aprovações

Consulta gerencial
```

---

# 29. E-commerce

O estoque e catálogo poderão futuramente alimentar uma loja virtual.

Possíveis recursos:

```text
Catálogo

Preços

Estoque

Pedidos

Clientes

Pagamentos
```

---

# 30. Indicadores avançados

Futuramente poderão existir análises como:

```text
Curva ABC

Giro de estoque

Margem por produto

Margem por categoria

Ruptura

Cobertura de estoque

Previsão de demanda

Sugestão de compra

Produtos sem giro
```

---

# 31. Inteligência artificial

O LMSys Market poderá futuramente utilizar IA para funcionalidades como:

```text
Sugestão de compra

Previsão de demanda

Detecção de anomalias

Análise de perdas

Análise de vendas

Assistente gerencial

Consulta em linguagem natural
```

Exemplo:

```text
"Quais produtos tiveram queda de vendas
nos últimos 30 dias?"
```

O sistema poderia consultar os dados e responder de maneira estruturada.

Essa funcionalidade não fará parte da primeira versão.

---

# 32. Estratégia de versões

Versões planejadas inicialmente:

```text
v0.1.0  Foundation

v0.2.0  Products

v0.3.0  Inventory

v0.4.0  Purchasing

v0.5.0  POS

v0.6.0  Cash Register

v0.7.0  Customers

v0.8.0  Financial

v0.9.0  Promotions

v0.10.0 Inventory Control

v0.11.0 Analytics

v0.12.0 Security & Audit

v1.0.0  Production Ready
```

As versões poderão sofrer ajustes conforme o desenvolvimento.

---

# 33. Critério geral de conclusão

Nenhum módulo será considerado concluído somente porque o código foi escrito.

Para ser considerado concluído deverá possuir:

```text
[ ] Modelagem

[ ] Domain

[ ] Application

[ ] Infrastructure

[ ] Persistência

[ ] Interface

[ ] Validações

[ ] Tratamento de erros

[ ] Integração

[ ] Testes automatizados quando aplicável

[ ] Testes manuais

[ ] Documentação

[ ] Commit

[ ] Aplicação funcionando
```

---

# 34. Checklist antes de integrar um módulo

Antes de integrar uma feature à `develop`:

```text
[ ] Projeto compila

[ ] Aplicação abre

[ ] Login continua funcionando

[ ] Navegação continua funcionando

[ ] Funcionalidade nova funciona

[ ] Funcionalidades anteriores continuam funcionando

[ ] Banco está atualizado

[ ] Migrations estão funcionando

[ ] Não existem erros críticos conhecidos

[ ] Testes passam

[ ] Documentação foi atualizada
```

---

# 35. Regra para migrations

Uma migration deverá representar uma mudança real necessária ao sistema.

Não criaremos antecipadamente todas as tabelas do roadmap.

Exemplo:

```text
Módulo Foundation
↓
Tabelas Foundation

Módulo Products
↓
Tabelas Products

Módulo Inventory
↓
Tabelas Inventory
```

Isso mantém o projeto controlável.

---

# 36. Regra para funcionalidades futuras

Não implementaremos funcionalidades apenas porque poderão existir algum dia.

A arquitetura poderá prever expansão futura, mas o desenvolvimento seguirá necessidades concretas.

Exemplo:

```text
API
Multi-loja completa
IA
E-commerce
Fiscal
TEF
```

serão adicionados quando chegarmos às fases correspondentes.

---

# 37. Regra de interface

Nenhum módulo operacional será considerado concluído sem uma interface funcional.

Exemplo:

Não consideraremos Produtos concluído somente porque existe:

```text
ProductService
ProductRepository
Product
```

Também deverá existir:

```text
ProductsView
ProductFormView
ProductsViewModel
ProductFormViewModel
```

e a funcionalidade deverá ser acessível pelo software.

---

# 38. Regra de testes

Testaremos principalmente:

- regras críticas;
- cálculos;
- mudanças de estado;
- operações financeiras;
- estoque;
- vendas;
- transações.

Não será necessário testar cada propriedade simples apenas para aumentar artificialmente a quantidade de testes.

O objetivo será proteger comportamentos importantes.

---

# 39. Regra de documentação

Cada módulo possuirá documentação própria dentro de:

```text
docs/modules/
```

Exemplo:

```text
00-foundation.md

01-products.md

02-inventory.md

03-suppliers-purchases.md

04-pos.md

05-cash-register.md

06-customers.md

07-financial.md

08-promotions.md

09-inventory-losses.md

10-dashboard-reports.md

11-audit-security.md
```

---

# 40. Conteúdo de cada documentação de módulo

Cada arquivo deverá possuir:

```text
Objetivo

Escopo

Requisitos envolvidos

Entidades

Banco de dados

Casos de uso

Telas

Fluxos

Regras de negócio

Testes

Critérios de aceitação

Arquivos importantes

Decisões técnicas

Problemas encontrados

Status
```

---

# 41. Status dos módulos

Utilizaremos os seguintes estados:

```text
PLANNED

IN_PROGRESS

TESTING

COMPLETED
```

Inicialmente:

```text
00 Foundation             PLANNED
01 Products               PLANNED
02 Inventory              PLANNED
03 Suppliers & Purchases  PLANNED
04 POS                    PLANNED
05 Cash Register          PLANNED
06 Customers              PLANNED
07 Financial              PLANNED
08 Promotions             PLANNED
09 Inventory & Losses     PLANNED
10 Dashboard & Reports    PLANNED
11 Audit & Security       PLANNED
12 Production Readiness   PLANNED
```

---

# 42. Próximo passo

O próximo documento será:

```text
docs/modules/00-foundation.md
```

Ele detalhará completamente o primeiro módulo do projeto.

Após sua conclusão, começaremos efetivamente a criar:

```text
LMSys.Market.sln
```

e os projetos:

```text
LMSys.Market.Domain

LMSys.Market.Application

LMSys.Market.Infrastructure

LMSys.Market.Desktop

LMSys.Market.Domain.Tests

LMSys.Market.Application.Tests

LMSys.Market.Infrastructure.Tests
```

---

# 43. Primeiro objetivo prático

Nosso primeiro objetivo técnico será transformar:

```text
GitHub + documentação
```

em:

```text
LMSys Market executando no Windows
```

O primeiro marco visual será:

```text
Splash Screen
      ↓
Login
      ↓
Dashboard
      ↓
Menu lateral
      ↓
Logout
```

Quando esse fluxo estiver funcionando, teremos oficialmente a primeira versão executável do LMSys Market.

---

# 44. Status atual

Neste momento o projeto encontra-se na fase:

```text
Planejamento e documentação
```

Documentos definidos:

```text
Requisitos Funcionais
Requisitos Não Funcionais
Regras de Negócio
Arquitetura
Modelagem do Banco
Roadmap
```

Próxima etapa:

```text
Especificação detalhada do Módulo 00 — Foundation
```

Depois:

```text
Início da implementação
```