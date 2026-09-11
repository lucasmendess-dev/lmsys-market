# LMSys Market

**Sistema profissional de gestão para supermercados e varejo.**

O **LMSys Market** é uma aplicação desktop desenvolvida para centralizar as principais operações de um supermercado, incluindo vendas, PDV, estoque, compras, fornecedores, clientes, financeiro, inventário, relatórios e gestão operacional.

> Projeto desenvolvido como parte da suíte de softwares **LMSys**.

---

## Status do projeto

🚧 **Em desenvolvimento**

Atualmente estamos na fase de levantamento de requisitos, arquitetura e preparação da estrutura inicial do projeto.

---

## Objetivo

Construir um sistema desktop moderno, modular e profissional capaz de atender às principais necessidades operacionais e administrativas de supermercados.

O projeto será desenvolvido incrementalmente.

Cada módulo deverá terminar em uma versão:

* executável;
* funcional;
* integrada;
* testável;
* documentada.

---

## Tecnologias

Tecnologias inicialmente definidas:

* C#
* .NET 10
* WPF
* MVVM
* Entity Framework Core
* PostgreSQL
* Git
* GitHub

---

## Arquitetura

A solução será inicialmente organizada nas seguintes camadas:

```text
LMSys.Market

src/
├── LMSys.Market.Domain
├── LMSys.Market.Application
├── LMSys.Market.Infrastructure
└── LMSys.Market.Desktop

tests/
├── LMSys.Market.Domain.Tests
├── LMSys.Market.Application.Tests
└── LMSys.Market.Infrastructure.Tests
```

### Domain

Responsável pelas entidades e regras centrais do negócio.

### Application

Responsável pelos casos de uso, serviços, DTOs e contratos da aplicação.

### Infrastructure

Responsável pelo acesso ao banco de dados, persistência e integrações externas.

### Desktop

Aplicação WPF responsável pela interface do usuário.

---

## Principais módulos

### Fundação

* estrutura da solução;
* banco de dados;
* autenticação;
* usuários;
* permissões;
* layout principal;
* navegação.

### Produtos

* produtos;
* categorias;
* marcas;
* unidades;
* códigos de barras;
* preços.

### Estoque

* posição de estoque;
* entradas;
* saídas;
* movimentações;
* ajustes;
* estoque mínimo.

### Fornecedores e Compras

* fornecedores;
* pedidos de compra;
* recebimento;
* atualização de estoque.

### PDV

* abertura do caixa;
* leitura de produtos;
* venda;
* descontos;
* pagamentos;
* cancelamentos;
* atalhos de teclado.

### Gestão de Caixa

* abertura;
* suprimentos;
* sangrias;
* fechamento;
* conferência.

### Clientes

* cadastro;
* histórico de compras;
* relacionamento com vendas.

### Financeiro

* contas a pagar;
* contas a receber;
* despesas;
* receitas;
* fluxo de caixa.

### Promoções

* preços promocionais;
* descontos;
* promoções por quantidade;
* regras promocionais.

### Inventário e Perdas

* inventário;
* ajustes;
* lotes;
* validade;
* perdas.

### Dashboard e Relatórios

* faturamento;
* ticket médio;
* vendas;
* estoque;
* compras;
* perdas;
* financeiro;
* indicadores gerenciais.

### Auditoria

* registro de operações;
* histórico de alterações;
* controle de ações críticas.

---

## Interface

O LMSys Market será desenvolvido com foco em uma experiência semelhante a softwares comerciais profissionais.

A aplicação contará com:

* menu lateral;
* dashboard;
* cards;
* tabelas modernas;
* atalhos;
* notificações;
* janelas modais;
* componentes reutilizáveis;
* interface específica para o PDV;
* design consistente entre os módulos.

---

## Estratégia de desenvolvimento

O desenvolvimento será realizado por módulos.

```text
Módulo 00 → Fundação
Módulo 01 → Produtos
Módulo 02 → Estoque
Módulo 03 → Fornecedores e Compras
Módulo 04 → PDV
Módulo 05 → Gestão de Caixa
Módulo 06 → Clientes
Módulo 07 → Financeiro
Módulo 08 → Promoções
Módulo 09 → Inventário e Perdas
Módulo 10 → Dashboard e Relatórios
Módulo 11 → Auditoria e Segurança
```

Nenhum módulo será considerado concluído sem:

* implementação;
* interface;
* integração;
* validações;
* testes;
* documentação.

---

## Primeiro objetivo operacional

A primeira versão operacional deverá permitir o fluxo:

```text
Login
  ↓
Cadastrar fornecedor
  ↓
Cadastrar produto
  ↓
Realizar compra
  ↓
Entrada no estoque
  ↓
Abrir caixa
  ↓
Realizar venda
  ↓
Receber pagamento
  ↓
Baixar estoque
  ↓
Fechar caixa
  ↓
Consultar a venda
```

---

## Organização

**LMSys**

Projeto: **LMSys Market**

Categoria: Sistema de gestão para supermercados e varejo.

---

## Autor

**Lucas Mendes da Silva**

---

## Licença

Licenciamento ainda não definido.
