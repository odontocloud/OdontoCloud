using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoCloud.Domain.Entities
{
    public class Anamnese
    {
        public Anamnese() { }
        public Anamnese(int idCliente, bool doencaCardiovascular, string descricaoDoencaCardiovascular, bool hipertencao, bool diabetes, bool doencaRespiratoria, bool doencaHepatica, bool osteoporose, bool coagulacaoSangramento, bool problemaGastrico, bool hepatite, bool tratamentoMedico, string descricaoTratamentoMedico, bool alergia, string descricaoAlergia, bool fumante, bool gravida, bool gravidaAmamentando, bool restricaoMedicamento, string descricaoRestricaoMedicamento, bool medicamentoUso, bool problemaAnestesia)
        {
            IdCliente = idCliente;
            DoencaCardiovascular = doencaCardiovascular;
            DescricaoDoencaCardiovascular = descricaoDoencaCardiovascular;
            Hipertencao = hipertencao;
            Diabetes = diabetes;
            DoencaRespiratoria = doencaRespiratoria;
            DoencaHepatica = doencaHepatica;
            Osteoporose = osteoporose;
            CoagulacaoSangramento = coagulacaoSangramento;
            ProblemaGastrico = problemaGastrico;
            Hepatite = hepatite;
            TratamentoMedico = tratamentoMedico;
            DescricaoTratamentoMedico = descricaoTratamentoMedico;
            Alergia = alergia;
            DescricaoAlergia = descricaoAlergia;
            Fumante = fumante;
            Gravida = gravida;
            GravidaAmamentando = gravidaAmamentando;
            RestricaoMedicamento = restricaoMedicamento;
            DescricaoRestricaoMedicamento = descricaoRestricaoMedicamento;
            MedicamentoUso = medicamentoUso;
            ProblemaAnestesia = problemaAnestesia;
        }

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public bool DoencaCardiovascular { get; set; }
        public string? DescricaoDoencaCardiovascular { get; set; }
        public bool Hipertencao { get; set; }
        public bool Diabetes { get; set; }
        public bool DoencaRespiratoria { get; set; }
        public bool DoencaHepatica { get; set; }
        public bool Osteoporose { get; set; }
        public bool CoagulacaoSangramento { get; set; }
        public bool ProblemaGastrico { get; set; }
        public bool Hepatite { get; set; }
        public bool TratamentoMedico { get; set; }
        public string? DescricaoTratamentoMedico { get; set; }
        public bool Alergia { get; set; }
        public string? DescricaoAlergia { get; set; }
        public bool Fumante { get; set; }
        public bool Gravida { get; set; }
        public bool GravidaAmamentando { get; set; }
        public bool RestricaoMedicamento { get; set; }
        public string? DescricaoRestricaoMedicamento { get; set; }
        public bool MedicamentoUso { get; set; }
        public bool ProblemaAnestesia { get; set; }
    }
}
