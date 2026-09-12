# LMSys Market
## Regras de Negócio

**Documento:** Regras de Negócio  
**Versão:** 0.1  
**Status:** Em elaboração

---

# 1. Usuários

## RN001 — Usuário inativo

Usuários inativos não poderão acessar o sistema.

---

## RN002 — Exclusão de usuário

Usuários que possuam histórico de operações não deverão ser fisicamente removidos do banco.

Deverão ser desativados.

---

## RN003 — Identificação das operações

Operações críticas deverão registrar o usuário responsável.

---

# 2. Produtos

## RN004 — Identificação do produto

Todo produto deverá possuir um identificador interno único.

---

## RN005 — Código de barras

Um código de barras não poderá estar associado simultaneamente a produtos diferentes.

---

## RN006 — Produto histórico

Produtos utilizados em movimentações anteriores não deverão ser fisicamente excluídos.

---

## RN007 — Produto inativo

Produtos inativos não poderão ser vendidos normalmente no PDV.

---

## RN008 — Preço

Produtos comercializados deverão possuir preço de venda válido.

---

## RN009 — Histórico de preços

Alterações de preço deverão preservar histórico quando o recurso estiver habilitado.

---

# 3. Estoque

## RN010 — Movimentação obrigatória

Nenhuma alteração relevante do estoque deverá ocorrer sem registro de movimentação correspondente.

---

## RN011 — Origem da movimentação

Toda movimentação deverá indicar sua origem.

Exemplos:

- venda;
- compra;
- perda;
- inventário;
- ajuste;
- cancelamento.

---

## RN012 — Ajuste manual

Ajustes manuais de estoque deverão exigir justificativa.

---

## RN013 — Usuário do ajuste

Todo ajuste manual deverá identificar o usuário responsável.

---

## RN014 — Estoque negativo

A possibilidade de estoque negativo dependerá da configuração definida pela empresa.

---

## RN015 — Cancelamento

Quando uma operação que movimentou estoque for cancelada, deverá ser gerada uma movimentação inversa quando aplicável.

O histórico original não deverá ser apagado.

---

# 4. Compras

## RN016 — Pedido de compra

Um pedido deverá possuir fornecedor antes de ser concluído.

---

## RN017 — Itens de compra

Pedidos deverão possuir pelo menos um item para avançarem para determinados estados.

---

## RN018 — Recebimento

Somente quantidades efetivamente recebidas deverão entrar no estoque.

---

## RN019 — Recebimento parcial

Um pedido poderá permanecer parcialmente recebido até que seja concluído ou encerrado.

---

## RN020 — Custo

O recebimento poderá atualizar informações de custo conforme regras definidas posteriormente.

---

## RN021 — Cancelamento de compra

Pedidos já recebidos não poderão ser simplesmente excluídos.

Qualquer reversão deverá respeitar as movimentações já realizadas.

---

# 5. Caixa

## RN022 — Abertura

Não será possível registrar vendas em um caixa que exija sessão aberta e não possua uma sessão válida.

---

## RN023 — Valor inicial

A abertura deverá registrar o valor inicial informado pelo operador.

---

## RN024 — Sessão de caixa

Cada sessão deverá possuir:

- operador;
- terminal;
- data e hora de abertura;
- situação;
- valor inicial.

---

## RN025 — Sangria

Toda sangria deverá registrar:

- valor;
- data e hora;
- responsável;
- motivo ou observação quando exigido.

---

## RN026 — Suprimento

Todo suprimento deverá registrar:

- valor;
- data e hora;
- responsável.

---

## RN027 — Fechamento

Uma sessão fechada não deverá aceitar novas vendas.

---

## RN028 — Diferença

Diferenças entre valor esperado e valor informado no fechamento deverão ser registradas.

---

# 6. Venda

## RN029 — Venda válida

Uma venda deverá possuir pelo menos um item antes da finalização.

---

## RN030 — Quantidade

Nenhum item poderá ser finalizado com quantidade igual ou inferior a zero.

---

## RN031 — Preço da venda

O preço efetivamente utilizado deverá ser armazenado no item da venda.

Alterações posteriores no cadastro do produto não poderão modificar vendas já realizadas.

---

## RN032 — Total da venda

O total deverá ser calculado com base nos itens, descontos e demais regras vigentes no momento da operação.

---

## RN033 — Pagamento integral

Uma venda somente poderá ser concluída quando os pagamentos forem suficientes para liquidar o valor exigido.

---

## RN034 — Pagamento múltiplo

Uma venda poderá possuir diversas formas de pagamento.

---

## RN035 — Troco

Troco deverá ser tratado adequadamente em pagamentos que permitam valor recebido superior ao total.

---

## RN036 — Finalização atômica

A conclusão da venda deverá ocorrer em uma única transação lógica.

Deverão ser persistidos de forma consistente:

- venda;
- itens;
- pagamentos;
- movimentações de estoque;
- movimentações relacionadas ao caixa.

---

## RN037 — Falha na finalização

Caso uma etapa crítica falhe, a venda não deverá permanecer parcialmente concluída.

---

## RN038 — Imutabilidade histórica

Após concluída, uma venda não deverá ser editada livremente como um cadastro comum.

Correções deverão utilizar operações específicas.

---

## RN039 — Cancelamento de venda

Vendas canceladas deverão permanecer registradas.

---

## RN040 — Estoque no cancelamento

Quando aplicável, o cancelamento deverá gerar movimentação de devolução ao estoque.

---

## RN041 — Auditoria do cancelamento

Cancelamentos deverão registrar o responsável e a data da operação.

---

# 7. Descontos

## RN042 — Permissão

Descontos somente poderão ser concedidos por usuários autorizados.

---

## RN043 — Limite

O sistema poderá possuir limite máximo de desconto por usuário ou perfil.

---

## RN044 — Autorização superior

Descontos acima do limite do operador poderão exigir autorização de usuário com permissão superior.

---

## RN045 — Registro

Descontos relevantes deverão manter identificação do responsável.

---

# 8. Promoções

## RN046 — Período

Promoções com período definido somente serão aplicáveis durante sua vigência.

---

## RN047 — Produto ativo

Promoções não deverão permitir venda normal de produtos desativados.

---

## RN048 — Conflito

Quando múltiplas promoções forem válidas para o mesmo produto, o sistema deverá utilizar uma política de prioridade definida.

---

## RN049 — Histórico da venda

A condição promocional utilizada deverá ser preservada no histórico da venda.

---

# 9. Inventário

## RN050 — Inventário em andamento

O sistema deverá controlar o estado do inventário.

---

## RN051 — Contagem

A quantidade encontrada deverá ser registrada separadamente da quantidade atualmente registrada no estoque.

---

## RN052 — Divergência

A diferença entre estoque físico e estoque do sistema deverá ser apresentada antes da confirmação.

---

## RN053 — Confirmação

Somente após a confirmação do inventário as diferenças deverão produzir ajustes de estoque.

---

## RN054 — Histórico

Inventários concluídos não deverão ser apagados livremente.

---

# 10. Perdas

## RN055 — Motivo obrigatório

Toda perda deverá possuir motivo.

---

## RN056 — Quantidade válida

A quantidade perdida deverá ser maior que zero.

---

## RN057 — Saída de estoque

A confirmação da perda deverá gerar movimentação de saída.

---

## RN058 — Responsável

O registro deverá identificar quem realizou a operação.

---

# 11. Financeiro

## RN059 — Valores positivos

Lançamentos financeiros deverão utilizar valores monetários válidos.

---

## RN060 — Data de vencimento

Contas que possuam vencimento deverão armazenar a data correspondente.

---

## RN061 — Pagamento

Uma conta paga deverá registrar a data do pagamento.

---

## RN062 — Histórico

Lançamentos financeiros ligados a operações anteriores não deverão ser simplesmente apagados caso isso comprometa a rastreabilidade.

---

# 12. Auditoria

## RN063 — Alterações críticas

Deverão ser auditadas especialmente operações como:

- alteração de preço;
- ajustes de estoque;
- cancelamentos;
- descontos acima de limites;
- sangrias;
- alterações de permissões;
- fechamento de caixa.

---

## RN064 — Registro da auditoria

Quando aplicável, a auditoria deverá armazenar:

- usuário;
- ação;
- entidade;
- identificador;
- data e hora;
- valor anterior;
- valor posterior.

---

## RN065 — Proteção do histórico

Usuários comuns não deverão conseguir alterar registros de auditoria.

---

# 13. Integridade

## RN066 — Exclusão lógica

Registros utilizados por operações históricas deverão preferencialmente utilizar exclusão lógica ou desativação.

---

## RN067 — Relacionamentos

O sistema deverá impedir operações que violem relacionamentos essenciais.

---

## RN068 — Transações críticas

Operações que alterem simultaneamente múltiplas entidades deverão utilizar transações quando necessário.

---

# 14. Evolução

## RN069 — Multi-loja

Mesmo que a primeira versão trabalhe com uma única operação, as decisões arquiteturais não deverão impedir futura existência de filiais.

---

## RN070 — Equipamentos

Integrações com leitores, balanças, impressoras e outros dispositivos deverão ser implementadas através de componentes desacoplados sempre que possível.

---

## RN071 — Fiscal

A implementação fiscal deverá ser tratada como módulo próprio e não deverá espalhar regras fiscais diretamente por toda a aplicação.

---

# 15. Regra fundamental do projeto

## RN072 — Estado funcional

Ao final de cada módulo, o LMSys Market deverá continuar executando e permitindo os testes correspondentes às funcionalidades já implementadas.

Não deverão existir longas etapas de desenvolvimento nas quais toda a aplicação permaneça inutilizável.