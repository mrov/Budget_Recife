using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Budget
    {
        [Key]
        public int _id { get; set; }
        public decimal ano_movimentacao { get; set; }
        public decimal mes_movimentacao { get; set; }
        public decimal orgao_codigo { get; set; }
        public string orgao_nome { get; set; }
        public decimal unidade_codigo { get; set; }
        public string unidade_nome { get; set; }
        public decimal categoria_economica_codigo { get; set; }
        public string categoria_economica_nome { get; set; }
        public decimal grupo_despesa_codigo { get; set; }
        public string grupo_despesa_nome { get; set; }
        public decimal modalidade_aplicacao_codigo { get; set; }
        public string modalidade_aplicacao_nome { get; set; }
        public decimal elemento_codigo { get; set; }
        public string elemento_nome { get; set; }
        public decimal subelemento_codigo { get; set; }
        public string subelemento_nome { get; set; }
        public decimal funcao_codigo { get; set; }
        public string funcao_nome { get; set; }
        public decimal subfuncao_codigo { get; set; }
        public string subfuncao_nome { get; set; }
        public decimal programa_codigo { get; set; }
        public string programa_nome { get; set; }
        public decimal acao_codigo { get; set; }
        public string acao_nome { get; set; }
        public decimal fonte_recurso_codigo { get; set; }
        public string fonte_recurso_nome { get; set; }
        public decimal empenho_ano { get; set; }
        public string empenho_modalidade_nome { get; set; }
        public decimal empenho_modalidade_codigo { get; set; }
        public decimal empenho_numero { get; set; }
        public decimal subempenho { get; set; }
        public string indicador_subempenho { get; set; }
        public decimal credor_codigo { get; set; }
        public string credor_nome { get; set; }
        public decimal modalidade_licitacao_codigo { get; set; }
        public string modalidade_licitacao_nome { get; set; }
        public string valor_empenhado { get; set; }
        public string valor_liquidado { get; set; }
        public string valor_pago { get; set; }
    }
}