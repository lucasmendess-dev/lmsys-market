# LMSys Market
## Requisitos Não Funcionais

**Documento:** Requisitos Não Funcionais  
**Versão:** 0.1  
**Status:** Em elaboração

---

# 1. Plataforma

## RNF001 — Aplicação desktop

O LMSys Market deverá ser uma aplicação desktop para ambiente Windows.

---

## RNF002 — Tecnologia

A aplicação será desenvolvida inicialmente utilizando:

- C#;
- .NET 10;
- WPF;
- MVVM;
- Entity Framework Core;
- PostgreSQL.

---

# 2. Interface

## RNF003 — Aparência profissional

A interface deverá possuir aparência compatível com softwares comerciais modernos.

Deverá ser evitada aparência padrão de aplicações antigas ou interfaces compostas exclusivamente por controles nativos sem identidade visual.

---

## RNF004 — Design System

O projeto deverá possuir componentes e estilos reutilizáveis.

Entre eles:

- botões;
- campos;
- ComboBoxes;
- DataGrids;
- cards;
- badges;
- modais;
- notificações;
- menus;
- barras de pesquisa;
- indicadores de carregamento.

---

## RNF005 — Consistência visual

Todas as telas deverão seguir os mesmos padrões de:

- espaçamento;
- tipografia;
- cores;
- bordas;
- ícones;
- estados;
- interação.

---

## RNF006 — Interface específica para PDV

O PDV deverá possuir interface otimizada para velocidade operacional e utilização intensa de teclado.

---

## RNF007 — Resoluções

A aplicação administrativa deverá adaptar-se adequadamente às principais resoluções utilizadas em computadores Windows.

---

# 3. Arquitetura

## RNF008 — Separação de responsabilidades

O projeto deverá ser dividido em camadas.

Estrutura inicial:

- Domain;
- Application;
- Infrastructure;
- Desktop.

---

## RNF009 — Baixo acoplamento

As camadas deverão possuir dependências controladas.

Regras de domínio não deverão depender da interface gráfica.

---

## RNF010 — MVVM

A aplicação WPF deverá utilizar o padrão MVVM.

A lógica de negócio não deverá ser implementada diretamente no code-behind das Views.

---

## RNF011 — Injeção de dependência

Os principais serviços deverão utilizar abstrações e injeção de dependência.

---

# 4. Persistência

## RNF012 — Banco relacional

O banco principal será PostgreSQL.

---

## RNF013 — ORM

O acesso principal aos dados utilizará Entity Framework Core.

---

## RNF014 — Migrations

Alterações estruturais no banco deverão ser controladas através de migrations.

---

## RNF015 — Integridade referencial

Relacionamentos relevantes deverão possuir restrições de integridade no banco.

---

# 5. Segurança

## RNF016 — Senhas protegidas

Senhas não poderão ser armazenadas em texto puro.

---

## RNF017 — Autorização no sistema

Funcionalidades sensíveis deverão validar permissões antes da execução.

---

## RNF018 — Princípio do menor privilégio

Usuários deverão possuir somente as permissões necessárias para exercer suas funções.

---

## RNF019 — Auditoria

Operações críticas deverão possuir registro de auditoria.

---

## RNF020 — Dados sensíveis

Informações sensíveis deverão ser tratadas adequadamente e não deverão aparecer em logs sem necessidade.

---

# 6. Performance

## RNF021 — Pesquisa rápida no PDV

A localização de produtos no PDV deverá possuir resposta adequada à operação de caixa.

---

## RNF022 — Grandes cadastros

O sistema deverá ser projetado para trabalhar com milhares de produtos sem degradação excessiva da experiência.

---

## RNF023 — Paginação

Consultas que possam retornar grandes quantidades de registros deverão suportar paginação ou carregamento controlado.

---

## RNF024 — Índices

Campos utilizados frequentemente em buscas deverão possuir índices adequados no banco de dados.

Exemplos:

- código de barras;
- código interno;
- descrição;
- CPF;
- CNPJ;
- número da venda.

---

# 7. Concorrência

## RNF025 — Múltiplos usuários

O sistema deverá permitir utilização simultânea por diferentes usuários.

---

## RNF026 — Múltiplos caixas

Mais de um caixa poderá registrar vendas simultaneamente.

---

## RNF027 — Consistência concorrente

Operações simultâneas não deverão provocar corrupção ou inconsistência dos dados.

---

# 8. Transações

## RNF028 — Operações atômicas

Processos críticos deverão utilizar transações no banco.

Exemplos:

- conclusão de venda;
- cancelamento de venda;
- recebimento de compra;
- confirmação de inventário;
- registro de perda;
- fechamento de caixa.

---

## RNF029 — Rollback

Em caso de falha durante uma operação transacional, o sistema deverá impedir gravação parcial inconsistente.

---

# 9. Tratamento de erros

## RNF030 — Tratamento centralizado

O sistema deverá possuir estratégia consistente de tratamento de exceções.

---

## RNF031 — Mensagens amigáveis

Erros apresentados ao usuário deverão ser compreensíveis.

Detalhes técnicos não deverão ser exibidos desnecessariamente.

---

## RNF032 — Logs

Falhas técnicas importantes deverão ser registradas.

---

# 10. Manutenibilidade

## RNF033 — Código organizado

O código deverá seguir convenções consistentes de nomenclatura e organização.

---

## RNF034 — Responsabilidade única

Classes deverão possuir responsabilidades bem definidas.

---

## RNF035 — Evitar duplicação

Regras comuns deverão ser centralizadas sempre que apropriado.

---

## RNF036 — Documentação

Decisões importantes de arquitetura e negócio deverão ser documentadas no repositório.

---

# 11. Testes

## RNF037 — Testes de domínio

Regras críticas de negócio deverão possuir testes automatizados sempre que viável.

---

## RNF038 — Testes de aplicação

Casos de uso críticos deverão ser testados.

---

## RNF039 — Testes antes da conclusão do módulo

Cada módulo deverá possuir validação antes de ser considerado concluído.

---

# 12. Versionamento

## RNF040 — Git

Todo o código deverá ser versionado utilizando Git.

---

## RNF041 — GitHub

O repositório oficial será hospedado no GitHub.

---

## RNF042 — Branch principal

A branch `main` deverá representar versões estáveis.

---

## RNF043 — Branch de desenvolvimento

A branch `develop` será utilizada para integração do desenvolvimento.

---

## RNF044 — Feature branches

Novas funcionalidades deverão preferencialmente ser desenvolvidas em branches `feature/*`.

---

# 13. Backup e recuperação

## RNF045 — Backup

A arquitetura deverá permitir implementação de rotinas de backup do banco.

---

## RNF046 — Restauração

Deverá ser possível restaurar dados a partir de backups válidos.

---

# 14. Escalabilidade

## RNF047 — Evolução modular

Novos módulos deverão poder ser adicionados sem necessidade de reescrever o núcleo inteiro da aplicação.

---

## RNF048 — Multi-loja futuro

A arquitetura deverá evitar decisões que impossibilitem futura implementação de múltiplas lojas ou filiais.

---

## RNF049 — API futura

A arquitetura deverá permitir futura introdução de uma API sem substituir obrigatoriamente todo o domínio da aplicação.

---

# 15. Usabilidade

## RNF050 — Operações rápidas

Operações utilizadas frequentemente deverão exigir o menor número razoável de interações.

---

## RNF051 — Atalhos

O PDV deverá priorizar atalhos de teclado para as principais operações.

---

## RNF052 — Feedback visual

A aplicação deverá informar claramente:

- carregamento;
- sucesso;
- erro;
- alerta;
- confirmação.

---

## RNF053 — Confirmações

Ações destrutivas ou críticas deverão solicitar confirmação quando apropriado.

---

# 16. Qualidade do desenvolvimento

## RNF054 — Sistema funcional durante a evolução

Cada etapa do desenvolvimento deverá preservar uma versão executável e testável da aplicação.

---

## RNF055 — Critério de conclusão

Um módulo somente será considerado concluído quando estiver:

- implementado;
- integrado;
- visualmente funcional;
- validado;
- testado;
- documentado.