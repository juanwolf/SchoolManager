//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Academy
    {
        public Academy()
        {
            this.Establishments = new HashSet<Establishment>();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Establishment> Establishments { get; set; }
    }
}
