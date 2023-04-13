using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoCloud.Domain.Entities
{
    public class Anamnese
    {
        public Anamnese(int? id, int idCliente, bool doencaCardiovascular, string? descricaoDoencaCardiovascular, bool hipertencao, bool diabetes, bool doencaRespiratoria, bool doencaHepatica, bool osteoporose, bool coagulacaoSangramento, bool problemaGastrico, bool hepatite, bool tratamentoMedico, string? descricaoTratamentoMedico, bool alergia, string? descricaoAlergia, bool fumante, bool gravida, bool gravidaAmamentando, bool restricaoMedicamento, string? descricaoRestricaoMedicamento, bool medicamentoUso, bool problemaAnestesia)
        {
            Id = id;
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

        public int? Id { get; private set; }
        public int IdCliente { get; private  set; }
        public bool DoencaCardiovascular { get; private set; }
        public string? DescricaoDoencaCardiovascular { get; private set; }
        public bool Hipertencao { get; private set; }
        public bool Diabetes { get; private set; }
        public bool DoencaRespiratoria { get; private set; }
        public bool DoencaHepatica { get; private set; }
        public bool Osteoporose { get; private set; }
        public bool CoagulacaoSangramento { get; private set; }
        public bool ProblemaGastrico { get; private set; }
        public bool Hepatite { get; private set; }
        public bool TratamentoMedico { get; private set; }
        public string? DescricaoTratamentoMedico { get; private set; }
        public bool Alergia { get; private set; }
        public string? DescricaoAlergia { get; private set; }
        public bool Fumante { get; private set; }
        public bool Gravida { get; private set; }
        public bool GravidaAmamentando { get; private set; }
        public bool RestricaoMedicamento { get; private set; }
        public string? DescricaoRestricaoMedicamento { get; private set; }
        public bool MedicamentoUso { get; private set; }
        public bool ProblemaAnestesia { get; private set; }
    }


}
