# LMSys Market
## Requisitos Funcionais

**Documento:** Requisitos Funcionais  
**Versão:** 0.1  
**Status:** Em elaboração  
**Produto:** LMSys Market  
**Plataforma:** Desktop Windows  
**Tecnologia principal:** C# / .NET / WPF

---

# 1. Objetivo

Este documento descreve os requisitos funcionais do LMSys Market.

O LMSys Market será um sistema desktop profissional destinado à gestão de supermercados e estabelecimentos varejistas.

O sistema deverá centralizar operações de:

- autenticação;
- usuários;
- produtos;
- preços;
- estoque;
- fornecedores;
- compras;
- clientes;
- ponto de venda;
- caixa;
- pagamentos;
- promoções;
- financeiro;
- inventário;
- perdas;
- relatórios;
- auditoria;
- configurações.

---

# 2. Autenticação

## RF001 — Autenticar usuário

O sistema deverá permitir que um usuário realize login utilizando suas credenciais.

O login deverá validar:

- usuário ou e-mail;
- senha;
- situação da conta.

---

## RF002 — Encerrar sessão

O usuário deverá poder encerrar sua sessão de forma segura.

---

## RF003 — Bloquear acesso de usuário inativo

Usuários desativados não poderão acessar o sistema.

---

## RF004 — Identificar usuário autenticado

O sistema deverá manter durante a sessão as informações do usuário atualmente autenticado.

---

## RF005 — Registrar acesso

O sistema deverá registrar informações relevantes sobre autenticações realizadas.

---

# 3. Usuários e permissões

## RF006 — Cadastrar usuário

O administrador deverá conseguir cadastrar usuários.

Dados mínimos:

- nome;
- login;
- e-mail;
- senha;
- perfil;
- status.

---

## RF007 — Editar usuário

Usuários autorizados deverão poder alterar dados de outros usuários.

---

## RF008 — Desativar usuário

O sistema deverá permitir desativar usuários sem remover seu histórico.

---

## RF009 — Cadastrar perfis

O sistema deverá permitir perfis como:

- administrador;
- gerente;
- operador de caixa;
- estoquista;
- comprador;
- financeiro.

---

## RF010 — Controlar permissões

O sistema deverá controlar acesso às funcionalidades conforme as permissões do usuário.

As permissões poderão incluir ações como:

- visualizar;
- cadastrar;
- editar;
- excluir;
- cancelar;
- aprovar;
- autorizar desconto;
- visualizar valores financeiros.

---

# 4. Produtos

## RF011 — Cadastrar produto

O sistema deverá permitir o cadastro de produtos.

Dados possíveis:

- código interno;
- descrição;
- descrição reduzida;
- categoria;
- marca;
- unidade de medida;
- custo;
- preço de venda;
- margem;
- estoque mínimo;
- estoque máximo;
- status;
- imagem;
- controle de lote;
- controle de validade;
- indicação de produto pesável.

---

## RF012 — Editar produto

O sistema deverá permitir alteração das informações cadastrais de um produto.

---

## RF013 — Desativar produto

Produtos poderão ser desativados sem serem excluídos do histórico.

---

## RF014 — Pesquisar produtos

A pesquisa deverá permitir localização por:

- código interno;
- código de barras;
- descrição;
- categoria;
- marca.

---

## RF015 — Cadastrar categorias

O sistema deverá permitir cadastrar e gerenciar categorias de produtos.

---

## RF016 — Cadastrar marcas

O sistema deverá permitir cadastrar e gerenciar marcas.

---

## RF017 — Cadastrar unidades de medida

O sistema deverá permitir unidades como:

- UN;
- KG;
- G;
- L;
- ML;
- CX;
- PCT.

---

## RF018 — Gerenciar códigos de barras

Um produto poderá possuir um ou mais códigos de barras.

---

## RF019 — Manter histórico de preços

Toda alteração de preço de venda deverá poder ser registrada para consulta posterior.

---

## RF020 — Manter histórico de custos

Alterações relevantes no custo de aquisição deverão ser registradas.

---

# 5. Estoque

## RF021 — Consultar estoque

O sistema deverá exibir a quantidade disponível de cada produto.

---

## RF022 — Registrar entrada de estoque

Entradas poderão ocorrer através de:

- recebimento de compra;
- devolução;
- ajuste;
- inventário;
- transferência futura.

---

## RF023 — Registrar saída de estoque

Saídas poderão ocorrer através de:

- venda;
- perda;
- ajuste;
- devolução ao fornecedor;
- transferência futura.

---

## RF024 — Registrar movimentação de estoque

Toda alteração de estoque deverá gerar uma movimentação.

A movimentação deverá identificar:

- produto;
- quantidade;
- tipo;
- data;
- usuário;
- origem;
- observação.

---

## RF025 — Alertar estoque mínimo

O sistema deverá identificar produtos cuja quantidade esteja igual ou abaixo do estoque mínimo.

---

## RF026 — Realizar ajuste de estoque

Usuários autorizados poderão realizar ajustes de estoque.

O ajuste deverá exigir justificativa.

---

## RF027 — Consultar histórico de movimentações

O sistema deverá permitir visualizar todas as movimentações de determinado produto.

---

## RF028 — Controlar lotes

Produtos configurados para controle por lote deverão possuir identificação de lote.

---

## RF029 — Controlar validade

O sistema deverá permitir informar datas de validade.

---

## RF030 — Alertar vencimentos

Produtos próximos da data de validade deverão ser identificados pelo sistema.

---

# 6. Fornecedores

## RF031 — Cadastrar fornecedor

O sistema deverá permitir cadastro contendo, quando aplicável:

- razão social;
- nome fantasia;
- CNPJ ou CPF;
- inscrição estadual;
- telefone;
- e-mail;
- endereço;
- contato comercial;
- observações.

---

## RF032 — Editar fornecedor

O sistema deverá permitir atualização dos dados do fornecedor.

---

## RF033 — Desativar fornecedor

Fornecedores utilizados anteriormente deverão poder ser desativados sem destruição de histórico.

---

## RF034 — Consultar histórico do fornecedor

Deverão ser consultáveis:

- pedidos;
- compras;
- produtos;
- valores;
- recebimentos.

---

# 7. Compras

## RF035 — Criar pedido de compra

O sistema deverá permitir criar pedidos de compra.

Cada pedido poderá conter:

- fornecedor;
- produtos;
- quantidades;
- custos;
- descontos;
- observações;
- previsão de entrega.

---

## RF036 — Controlar status do pedido

Um pedido poderá possuir estados como:

- rascunho;
- pendente;
- aprovado;
- enviado;
- parcialmente recebido;
- recebido;
- cancelado.

---

## RF037 — Receber pedido de compra

O sistema deverá permitir registrar o recebimento das mercadorias.

---

## RF038 — Atualizar estoque após recebimento

O recebimento confirmado deverá gerar automaticamente entrada no estoque.

---

## RF039 — Permitir recebimento parcial

O sistema deverá suportar entrega parcial de pedidos.

---

## RF040 — Registrar divergência de recebimento

Diferenças entre pedido e mercadoria recebida poderão ser registradas.

---

## RF041 — Sugerir necessidade de compra

O sistema poderá sugerir reposição com base em:

- estoque atual;
- estoque mínimo;
- histórico de vendas;
- consumo médio.

---

# 8. Clientes

## RF042 — Cadastrar cliente

O cadastro poderá conter:

- nome;
- CPF;
- telefone;
- e-mail;
- endereço;
- data de nascimento;
- observações.

---

## RF043 — Editar cliente

O sistema deverá permitir alteração dos dados cadastrais.

---

## RF044 — Pesquisar cliente

A pesquisa poderá utilizar:

- nome;
- CPF;
- telefone.

---

## RF045 — Consultar histórico de compras

O sistema deverá apresentar compras vinculadas ao cliente.

---

## RF046 — Consultar total consumido

O sistema deverá permitir calcular o valor comprado pelo cliente em determinado período.

---

# 9. Ponto de Venda — PDV

## RF047 — Abrir PDV

Um operador autorizado deverá poder iniciar a operação do ponto de venda.

---

## RF048 — Localizar produto no PDV

Produtos poderão ser encontrados através de:

- código de barras;
- código interno;
- descrição.

---

## RF049 — Adicionar produto à venda

O operador deverá conseguir adicionar produtos à venda em andamento.

---

## RF050 — Alterar quantidade

O operador poderá alterar quantidades conforme suas permissões.

---

## RF051 — Remover item da venda

Itens poderão ser cancelados conforme as permissões do operador.

---

## RF052 — Aplicar desconto em item

Usuários autorizados poderão aplicar desconto sobre determinado item.

---

## RF053 — Aplicar desconto na venda

Usuários autorizados poderão conceder desconto sobre o total da venda.

---

## RF054 — Identificar cliente

Uma venda poderá opcionalmente ser vinculada a um cliente.

---

## RF055 — Calcular subtotal

O sistema deverá calcular automaticamente os subtotais dos itens.

---

## RF056 — Calcular total

O sistema deverá apresentar o valor total atualizado da venda.

---

## RF057 — Utilizar atalhos de teclado

O PDV deverá oferecer atalhos para as principais operações.

---

# 10. Pagamentos

## RF058 — Registrar pagamento em dinheiro

O sistema deverá aceitar pagamentos em dinheiro.

---

## RF059 — Registrar pagamento via PIX

O sistema deverá possuir suporte lógico para pagamentos via PIX.

---

## RF060 — Registrar pagamento em cartão

O sistema deverá aceitar registro de pagamentos por:

- cartão de débito;
- cartão de crédito.

---

## RF061 — Permitir múltiplas formas de pagamento

Uma mesma venda poderá utilizar mais de uma forma de pagamento.

---

## RF062 — Calcular troco

Em pagamentos em dinheiro, o sistema deverá calcular automaticamente o troco.

---

## RF063 — Validar valor recebido

A soma dos pagamentos deverá ser compatível com o total da venda antes da conclusão.

---

# 11. Vendas

## RF064 — Finalizar venda

Ao finalizar uma venda, o sistema deverá:

1. registrar a venda;
2. registrar seus itens;
3. registrar os pagamentos;
4. gerar movimentações de estoque;
5. atualizar os valores do caixa.

---

## RF065 — Cancelar venda

Usuários autorizados poderão cancelar uma venda.

---

## RF066 — Reverter estoque após cancelamento

Quando aplicável, o cancelamento deverá devolver as quantidades ao estoque através de movimentações.

---

## RF067 — Consultar vendas

O sistema deverá permitir localizar vendas através de filtros como:

- número;
- período;
- operador;
- cliente;
- caixa.

---

## RF068 — Consultar detalhes da venda

A consulta deverá apresentar:

- itens;
- quantidades;
- preços;
- descontos;
- pagamentos;
- operador;
- horários;
- status.

---

# 12. Gestão de Caixa

## RF069 — Abrir caixa

O operador deverá informar o valor inicial do caixa.

---

## RF070 — Impedir múltiplas aberturas indevidas

O sistema deverá impedir que o mesmo terminal ou operador abra sessões incompatíveis simultaneamente.

---

## RF071 — Registrar suprimento

O sistema deverá permitir registrar entrada extraordinária de dinheiro no caixa.

---

## RF072 — Registrar sangria

O sistema deverá permitir registrar retirada de valores do caixa.

---

## RF073 — Exigir identificação em operações de caixa

Sangrias e suprimentos deverão registrar o usuário responsável.

---

## RF074 — Fechar caixa

O sistema deverá permitir encerrar uma sessão de caixa.

---

## RF075 — Calcular valor esperado

No fechamento, o sistema deverá calcular valores esperados de acordo com as movimentações registradas.

---

## RF076 — Registrar diferença de caixa

O sistema deverá registrar diferenças entre valor esperado e valor informado.

---

## RF077 — Consultar histórico de caixas

Usuários autorizados poderão consultar sessões anteriores.

---

# 13. Promoções

## RF078 — Criar promoção

O sistema deverá permitir criar promoções para produtos.

---

## RF079 — Definir período promocional

Uma promoção poderá possuir data e hora de início e término.

---

## RF080 — Aplicar preço promocional

Um produto poderá possuir preço promocional temporário.

---

## RF081 — Criar desconto percentual

O sistema deverá permitir promoção através de percentual de desconto.

---

## RF082 — Criar promoção por quantidade

O sistema deverá suportar promoções baseadas em quantidade.

Exemplo:

Leve 3 por R$ 10,00.

---

## RF083 — Controlar conflitos entre promoções

O sistema deverá possuir regra definida para situações em que mais de uma promoção se aplique ao mesmo item.

---

# 14. Inventário

## RF084 — Criar inventário

Usuários autorizados poderão iniciar processos de inventário.

---

## RF085 — Registrar contagem física

O sistema deverá permitir informar a quantidade fisicamente encontrada.

---

## RF086 — Comparar estoque físico e sistema

O inventário deverá mostrar divergências entre estoque registrado e contagem.

---

## RF087 — Confirmar inventário

Ao confirmar um inventário, diferenças deverão gerar movimentações de ajuste.

---

# 15. Perdas

## RF088 — Registrar perda

O sistema deverá permitir registrar perdas de produtos.

---

## RF089 — Classificar perda

A perda poderá possuir motivos como:

- vencimento;
- quebra;
- avaria;
- furto;
- consumo interno;
- outros.

---

## RF090 — Atualizar estoque após perda

A confirmação de uma perda deverá gerar saída de estoque.

---

## RF091 — Consultar histórico de perdas

O sistema deverá permitir análise por:

- produto;
- motivo;
- período;
- usuário;
- valor.

---

# 16. Financeiro

## RF092 — Cadastrar conta a pagar

O sistema deverá permitir registrar obrigações financeiras.

---

## RF093 — Registrar pagamento

Contas a pagar poderão ser marcadas como pagas.

---

## RF094 — Cadastrar conta a receber

O sistema deverá permitir registrar valores a receber.

---

## RF095 — Registrar recebimento

Contas a receber poderão ser baixadas após recebimento.

---

## RF096 — Registrar despesa

O sistema deverá permitir registrar despesas operacionais.

---

## RF097 — Registrar receita

O sistema deverá permitir receitas que não sejam originadas diretamente pelo PDV.

---

## RF098 — Categorizar lançamentos financeiros

Receitas e despesas poderão ser organizadas em categorias.

---

## RF099 — Consultar fluxo financeiro

O sistema deverá permitir análise de entradas e saídas em determinado período.

---

# 17. Dashboard

## RF100 — Exibir faturamento

O dashboard deverá apresentar faturamento do período selecionado.

---

## RF101 — Exibir quantidade de vendas

O painel deverá mostrar quantidade de vendas realizadas.

---

## RF102 — Exibir ticket médio

O sistema deverá calcular e apresentar ticket médio.

---

## RF103 — Exibir produtos mais vendidos

O dashboard deverá apresentar ranking de produtos.

---

## RF104 — Exibir alertas de estoque

Produtos com estoque baixo deverão ser destacados.

---

## RF105 — Exibir alertas de validade

Produtos próximos do vencimento poderão aparecer no dashboard.

---

## RF106 — Exibir resumo financeiro

O sistema poderá apresentar indicadores resumidos de receitas e despesas.

---

# 18. Relatórios

## RF107 — Gerar relatório de vendas

O sistema deverá permitir análise por diferentes períodos e filtros.

---

## RF108 — Gerar relatório de estoque

O sistema deverá gerar relatórios de posição e movimentação de estoque.

---

## RF109 — Gerar relatório de compras

As compras poderão ser analisadas por:

- período;
- fornecedor;
- produto.

---

## RF110 — Gerar relatório de perdas

O sistema deverá apresentar perdas em quantidade e valor.

---

## RF111 — Gerar relatório financeiro

O sistema deverá apresentar informações financeiras consolidadas.

---

## RF112 — Gerar relatório de margem

O sistema deverá permitir análise aproximada de margem entre custo e venda.

---

# 19. Auditoria

## RF113 — Registrar operações críticas

O sistema deverá registrar ações consideradas críticas.

---

## RF114 — Registrar usuário responsável

Cada registro de auditoria deverá identificar o responsável.

---

## RF115 — Registrar data e hora

Toda ocorrência de auditoria deverá armazenar data e hora.

---

## RF116 — Registrar alteração de valores

Sempre que aplicável, deverão ser armazenados:

- valor anterior;
- valor posterior.

---

## RF117 — Consultar auditoria

Usuários autorizados poderão pesquisar os registros de auditoria.

---

# 20. Configurações

## RF118 — Configurar empresa

O sistema deverá permitir informar dados da empresa.

---

## RF119 — Configurar parâmetros de estoque

Parâmetros como permissão para estoque negativo deverão ser configuráveis.

---

## RF120 — Configurar limites de desconto

O sistema deverá permitir limites conforme perfil ou configuração administrativa.

---

## RF121 — Configurar informações do PDV

O sistema deverá permitir configurações relacionadas ao ambiente de caixa.

---

# 21. Integrações futuras

Os seguintes recursos deverão ser considerados na evolução da arquitetura, mas não fazem parte obrigatoriamente da primeira versão:

- NFC-e;
- SAT quando aplicável;
- TEF;
- PIX integrado;
- balanças;
- leitores;
- impressoras térmicas;
- etiquetas;
- e-commerce;
- marketplaces;
- delivery;
- WhatsApp;
- aplicativos móveis;
- integração entre filiais.

---

# 22. Critério de evolução

Um requisito poderá sofrer alterações durante o desenvolvimento caso novas regras de negócio sejam identificadas.

Toda alteração relevante deverá ser documentada e versionada no repositório.