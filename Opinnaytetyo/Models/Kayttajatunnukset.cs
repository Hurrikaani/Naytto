//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Opinnaytetyo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Kayttajatunnukset
    {
        public int KayttajatunnusID { get; set; }

        public string Kayttajatunnus { get; set; }
        public string Salasana { get; set; }
        public Nullable<System.DateTime> RekisteröiytmisPVM { get; set; }
    }
}