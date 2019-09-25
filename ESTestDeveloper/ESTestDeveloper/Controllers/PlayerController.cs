using ESTestDeveloper.Libraries;
using ESTestDeveloper.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ESTestDeveloper.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        // GET api/player
        /// <summary>Return a list of all the player sorted by id</summary>
        /// <response code="200">Succesful operation </response>
        [ProducesResponseType(typeof(List<Player>), 200)]   // Created
        [HttpGet]
        public IActionResult Get()
        {
            var result = PlayerManager.GetAllPlayers();
            return Ok(result);
        }

        // GET api/player/5
        /// <summary>Find player by id</summary>
        /// <param name="id">Id of player to return</param>
        /// <response code="200">Succesful operation </response>
        /// <response code="404">No player matching the id</response>
        [ProducesResponseType(typeof(Player), 200)]   // Created
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = PlayerManager.GetPlayersById(id);
            if (result != null)
                return Ok(result);
            return NotFound();
        }

        // DELETE api/player/5
        /// <summary>Delete a Player</summary>
        /// <param name="id">Id of player to delete</param>
        /// <response code="200">Succesful operation </response>
        /// <response code="404">No player matching the id</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (PlayerManager.DeletePlayerById(id))
                return Ok();
            return NotFound();
        }
    }
}