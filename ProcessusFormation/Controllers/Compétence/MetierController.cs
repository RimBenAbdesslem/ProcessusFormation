using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProcessusFormation.Data;
using ProcessusFormation.Models;
using ProcessusFormation.Models.Compétence;

namespace ProcessusFormation.Controllers.Compétence
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetierController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public MetierController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("RegisterMetier")]
        public async Task<IActionResult> PostBesoinFormation(MetierModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var metier = new MetierModel()
            {

                DomaineId = model.DomaineId,
                UserId = model.UserId,
                LabelId = model.LabelId,
                Niveau = model.Niveau,

            };

            var result = await _context.Metiers.AddAsync(metier);
            _context.SaveChanges();
            return Ok(new { });

        }
        [HttpPost]
        [Route("PostGet")]

        public IActionResult PostGetMetier(MetierModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            //  GetuserSelected(model);
            //   GetAllLabel(model);
            //  GetAllDomaine(model);
            return Ok();
        }
        //Get Metier selon IDUser
        [HttpGet]
        [Route("GetAllmetieruser/{UserId}")]
        public IEnumerable<Object> GetUserMetier(string UserId)
        {
            var metier = _context.Metiers.Find(UserId);
            if (metier == null)
            {
                yield return (null);
            };
            yield return (metier);
        }
        //Get all 
        [HttpGet]
        [Route("GetAllDomaineuser/{id}")]
        public IEnumerable<Object> GetAllDomaine(string id)
        {
            List<int> ListId = new List<int>();
            List<DomaineModel> List = new List<DomaineModel>();
            var metiers = _context.Metiers;
            var domaines = _context.Domaines;
            if (metiers == null)
            {
                yield return (null);
            }
            // je doit recuperer dans une liste tout les labelId qui correspond à l'utilisateur element.UserId == model.UserId
            foreach (var element in metiers)
            {
                if (element.UserId == id)//&& element.LabelId == model.LabelId
                {
                    ListId.Add(element.DomaineId);
                    //   yield return (element);

                };
            }
            //ici il faut retourner la liste de label qui correspant au utilisateur d'id element.UserId == model.UserId

            for (int j = 0; j < ListId.Count; j++)
            {
                foreach (var domaine in domaines)
                {
                    if (ListId[j] == domaine.DomaineId)
                    {
                        List.Add(domaine);
                        //  return eval;
                    }

                }
            }
            for (int j = 0; j < List.Count; j++)
            {
                yield return List[j];
            }



        }
        [HttpGet]
        [Route("GetAllUserLabel/{id}")]
        public IEnumerable<Object> GetAllLabel(string id)
        {
            List<int> ListId = new List<int>();
            List<LabelModel> List = new List<LabelModel>();
            var metiers = _context.Metiers;
            var labels = _context.Labels;
            if (metiers == null)
            {
                yield return (null);
            }
            // je doit recuperer dans une liste tout les labelId qui correspond à l'utilisateur element.UserId == model.UserId
            foreach (var element in metiers)
            {
                if (element.UserId == id) //&& element.LabelId == model.LabelId
                {
                    ListId.Add(element.LabelId);
                    //    yield return (element);

                };
            }
            //ici il faut retourner la liste de label qui correspant au utilisateur d'id element.UserId == model.UserId

            for (int j = 0; j < ListId.Count; j++)
            {
                foreach (var label in labels)
                {
                    if (ListId[j] == label.LabelId)
                    {
                        List.Add(label);
                        //  return eval;
                    }

                }
            }
            for (int j = 0; j < List.Count; j++)
            {
                yield return List[j];
            }
        }

        public static class obj
        {
            public static int labelId=0;
            public static int Niveau=0;
          //  public static string UserName = "";
        };
        [HttpGet]
        [Route("Getuser/{id}")]
        public async Task<Object> Getuser(string id)
        {
            var user =await _userManager.FindByIdAsync(id);
            return user;


        }
        [HttpGet]
        [Route("GetuserSelected/{id}")]
        public  IEnumerable<Object> GetuserSelected(string id)
        {
       
        var metiers = _context.Metiers;
           
            List<Object> List = new List<Object>();
            //  var user =  _userManager.FindByIdAsync(id);
         //  var  user = _userManager.FindByIdAsync(id);
            foreach (var element in metiers)
            {
                if (element.UserId == id) //&& element.LabelId == model.LabelId
                {
                    obj.labelId = element.LabelId;
                    obj.Niveau = element.Niveau;
                //   obj.UserName = user.UserName + user.FullName;
                    List.Add(new{ obj.labelId,obj.Niveau});

                }
            };


                 return List;
           
        }     

    }
}     
        



        

// var applicationUser =  _userManager.FindByIdAsync(labele.UserId);

// var label = _context.Labels;
//  var metier = _context.Metiers;

//  foreach(var element in metier)
// {
//     yield return (element);
//    if ((element.UserId == labele.UserId) && (element.LabelId == labele.LabelId))
//  {
//      yield return (element);
//      foreach (LabelModel lab in label)
//     {

//       if (lab.LabelId == labele.LabelId)
//     {
//         yield return (lab);
//    }

// }

//  }

//   }