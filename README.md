
### Funcionalidades:
**a) Gerar chaves automáticas e manuais**
O objecto `ticket` tem de poder ser preenchido por um gerador de chaves automaticas.

**b) Gestão monetária**
As entidades que lidam com dinheiro tem um atributo `balance` que representa a liquidez. 

**c) Entidade Euromilhões que vai receber as apostas e as funcionalidades para seu funcionamento**
This is the big one, é aqui que se vai verificar as chaves contra a chave vencedora e com base nisso, realizar todas as operações

**d) Data do sistema e uso de data**
É necessario iterar um ciclo conforme a data do sistema, a cada sexta-feira a entidade euromilhoes efectua o sorteio

**e) Sexta-feira é o sorteio Euromilhões**
see above

**f) Possibilidade de sorteio semanalmente**
see above

**g) Pesquisar as apostas entre data/sorteio/nif**
As apostas e sorteios são exportados para ficheiros, para permitir posteriormente pesquisar estes dados

**h) Importar chaves ou exportar chaves de um determinado cliente**
Tem que ser possivel ler um ficheiro para passar o conteudo á uma chave preenchida manualmente. 

**i) Validações**
Self explanatory

**j) Cliente começa um saldo de 100 euros cada aposta tem um preço de 2,5**
O objecto `cliente` é instanciado com um `balance = 100`
Apostas no euromilhoes deduzem do `cliente.balance`

**k) Os prémios serão baseados em 10x o dinheiro recebido das apostas**

Um true na comparação de chaves devolve 10x a soma das apostas