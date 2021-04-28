using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //pocetna ruta je: api/carActivities/
    public class CarActivitiesController : BaseApiController
    {

        [HttpGet] //api/carActivities/
        public async Task<ActionResult<List<CarActivity>>> GetActivities() {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")] //api/carActivities/id
        public async Task<ActionResult<CarActivity>> GetOneActivity(Guid id) { //sta prosledjujemo kao parametar
            //mora da se prosledi u {} zagradama 
            return await Mediator.Send(new OneActivity.Query{Id = id}); //prosledjumeo novu klasu koju smo napravili u Activities folderu sa definisanim parametrima
        }

        [HttpPost] //api/carActivities/
        public async Task<IActionResult> CreateNewActivity(CarActivity carActivity) {
            return Ok(await Mediator.Send(new CreateActivity.Command{CarActivity = carActivity}));
        }

        [HttpPut("{id}")] //api/carActivities/id
        public async Task<IActionResult> EditOneActivity(Guid id, CarActivity carActivity) {
            carActivity.Id = id; //postavljam carActivity na tacan activity, zasto prosledjujem i ID niko ne zna
            return Ok(await Mediator.Send(new EditActivity.Command{CarActivity = carActivity}));
        }

        [HttpDelete("{id}")] //api/carActivities/id
        public async Task<IActionResult> DeleteOneActivity(Guid id) {
            return Ok(await Mediator.Send(new DeleteActivity.Command{Id = id}));
        }
        
    }
}