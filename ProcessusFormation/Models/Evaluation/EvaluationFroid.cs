﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessusFormation.Models.Evaluation
{
    public class EvaluationFroid
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public string Lieu { get; set; }
        public string Organisme { get; set; }
        public string Formateur { get; set; }
        public DateTime Date_Debut { get; set; }
        public DateTime Date_Fin { get; set; }
        public string Nom_Participant { get; set; }
        public string Prenom_Participant { get; set; }
        public string Matricule { get; set; }
        public string Fonction { get; set; }
        public string Direction { get; set; }
        public DateTime Date_Evaluation_Froid { get; set; }
        public string question_A { get; set; }
        public string question_B { get; set; }
        public string question_C { get; set; }
        public string Lesquelles { get; set; } //
        public string PourquoiA { get; set; }//
        public string Autres1 { get; set; }//
       
        public string Comment { get; set; }//
        public string PourquoiB { get; set; }//
       
        public string Commentaire1 { get; set; }//
        public string Critere1 { get; set; }//
        public string Critere2 { get; set; }//
        public string Critere3 { get; set; }//
        public string Critere4 { get; set; }//
        public string Critere5 { get; set; }//
        public string Critere6 { get; set; }//
        public string Critere7 { get; set; }//
        public string Critere8 { get; set; }//
        public string Critere9 { get; set; }//
        public string Autres2 { get; set; }//
        public string Sinon{ get; set; }//
       


    }
}
