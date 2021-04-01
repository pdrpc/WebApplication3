using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebApplication3
{
    [Table("Endereco")]
    public class Endereco
    {
        [Key]
        [Column("ID")]
        [Display(Name = "Id")]
        public Guid EnderecoId { get; set; }

        [JsonProperty("cep")]
        [Column("Cep")]
        [Display(Name = "Cep")]
        public string Cep { get; set; }

        [JsonProperty("logradouro")]
        [Column("Logradouro")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("complemento")]
        [Column("Complemento")]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [JsonProperty("bairro")]
        [Column("Bairro")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [JsonProperty("localidade")]
        [Column("Localidade")]
        [Display(Name = "Localidade")]
        public string Localidade { get; set; }

        [JsonProperty("uf")]
        [Column("UF")]
        [Display(Name = "UF")]
        public string Uf { get; set; }

        [JsonProperty("ibge")]
        [Column("Ibge")]
        [Display(Name = "IBGE")]
        public long Ibge { get; set; }

        [JsonProperty("gia")]
        [Column("Gia")]
        [Display(Name = "Gia")]
        public long Gia { get; set; }

        [JsonProperty("ddd")]
        [Column("Ddd")]
        [Display(Name = "DDD")]
        public long Ddd { get; set; }

        [JsonProperty("siafi")]
        [Column("Siafi")]
        [Display(Name = "Siafi")]
        public long Siafi { get; set; }
    }


}