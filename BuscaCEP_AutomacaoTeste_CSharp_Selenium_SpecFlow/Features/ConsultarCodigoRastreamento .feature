Feature: Busca Codigo de Rastreamento
	Eu como usuário
	desejo buscar o código de rastreamento no site dos correios
	para acompanhar o envio do objeto

@mytag
Scenario Outline: 3) Buscar codigo de rastreamento que nao existe
	Given que acesse o site correios
	When desejar busca o <codigo de rastreamento>
	Then o site deve retornar que codigo de rastreamento nao existe
	And fechar o navegador
	Examples:
	| codigo de rastreamento		|
	| SS987654321BR					|