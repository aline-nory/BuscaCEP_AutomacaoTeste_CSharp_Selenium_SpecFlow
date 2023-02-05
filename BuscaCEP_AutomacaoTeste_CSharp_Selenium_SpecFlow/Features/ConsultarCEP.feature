Feature: Busca CEP
	Eu como usuário
	desejo buscar o CEP no site dos correios
	para visualizar o resultado da busca

@mytag
Scenario Outline: 1) Buscar cep que nao existe
	Given que acesse o site correios
	When desejar buscar <cep>
	Then o site deve retornar que endereco nao existe
	And voltar para a tela inicial
	Examples:
	| cep      |
	| 80700000 |

@mytag
Scenario Outline: 2) Buscar cep com sucesso
	Given que acesse o site correios
	When desejar buscar <cep>
	Then o site deve retornar o <endereco> com sucesso
	And voltar para a tela inicial
	Examples:
	| cep       | endereco                             |
	| 01013-001 | Rua Quinze de Novembro, São Paulo/SP |