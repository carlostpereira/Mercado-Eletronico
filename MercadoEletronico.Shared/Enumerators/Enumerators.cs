using System.ComponentModel;

namespace MercadoEletronico.Shared.Enumerators
{
    public enum StatusPedido
	{
		[Description("APROVADO")]
		Aprovado = 0,

		[Description("APROVADO_VALOR_A_MENOR")]
		AprovadoValorAMenor = 1,

		[Description("APROVADO_VALOR_A_MAIOR")]
		AprovadoValorAMaior = 3,

		[Description("APROVADO_QTD_A_MAIOR")]
		AprovadoQuantidadeAMaior = 4,

		[Description("REPROVADO")]
		Reprovado = 5,

		[Description("CODIGO_PEDIDO_INVALIDO TESTE")]
		CodigoPedidoInvalido = 6,

		[Description("APROVADO_QTD_A_MENOR")]
		AprovadoQuantidadeAMenor = 7

	}
}
