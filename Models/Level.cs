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
    
    public partial class Level
    {
        public Level()
        {
            this.Pupils = new HashSet<Pupil>();
        }
    
        public System.Guid Id { get; set; }
        public string Title { get; set; }
        public System.Guid Cycle_Id { get; set; }
    
        public virtual Cycle Cycle { get; set; }
        public virtual ICollection<Pupil> Pupils { get; set; }
    }
}