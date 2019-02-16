using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge1HackTeam3.Models
{

    public class ResponseDTO
    {
        public Metadata _MetaData { get; set; }
        public List<Record> Records { get; set; }
    }

    public class Metadata
    {
        public string page { get; set; }
        public int page_count { get; set; }
        public int start_index { get; set; }
        public int end_index { get; set; }
        public int total_count { get; set; }
        public string current_page { get; set; }
        public string next_page { get; set; }
    }

    public class Record
    {
        public string vlr_latitude { get; set; }
        public string vlr_longitude { get; set; }
        public string cod_munic { get; set; }
        public string cod_cnes { get; set; }
        public string nom_estab { get; set; }
        public string dsc_endereco { get; set; }
        public string dsc_bairro { get; set; }
        public string dsc_cidade { get; set; }
        public string dsc_telefone { get; set; }
        public string dsc_estrut_fisic_ambiencia { get; set; }
        public string dsc_adap_defic_fisic_idosos { get; set; }
        public string dsc_equipamentos { get; set; }
        public string dsc_medicamentos { get; set; }
        public string co_cep { get; set; }
        public double distance { get; set; }
    }

    public class RootObject
    {
        public Metadata _metadata { get; set; }
        public List<Record> records { get; set; }
    }

}