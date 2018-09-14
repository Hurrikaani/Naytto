using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Opinnaytetyo.ViewModels
{
    public class OppilasViewModel
    {
        //oppilaat alkaa

        public int OpiskelijaID { get; set; }
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public string Puhelin { get; set; }
        public string Email { get; set; }
        public string Osoite { get; set; }
        public string Lisatiedot { get; set; }

        //käyttäjätiedot alkaa
        public int? KayttajatunnusID { get; set; }
        public string Kayttajatunnus { get; set; }
        public string Salasana { get; set; }
        public Nullable<System.DateTime> RekisteröiytmisPVM { get; set; }

        //Postitoimipaikat alkaa

        public string Postinumero { get; set; }
        public string Postitoimipaikka { get; set; }
        public int? PostinumeroID { get; set; }


    }
}