a)SELECT  COUNT(o.ID), o.datacontratacao, c.nome from os o, cliente c;

b)SELECT  ID, s.nomeServico, s.valorfinal, s.custoempresa, COUNT(*) count FROM  OS HAVING (*) >1;

c)SELECT  s.ID, s.nomeservico, s.valorfinal, s.custoempresa COUNT(s.id) AS idOs FROM serviço s INNER JOIN OS o ON s.ID = o.IDServico GROUP BY s.ID ORDER BY idOs;

d)UPDATE serviço s SET  s.valorfinal = valorfinal  *1.12;

e)DELETE OS  where id = (select max(o.ID) from OS);

f)INSERT INTO cliente (`nome´, `email´, `datanasc´, `celular´, `residencial´)
 VALUES ('Teste200', 'tes200@teste.com', '2017-01-04 00:00:00', '(31)987670987', '(31)33334567');