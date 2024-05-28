using Microsoft.AspNetCore.Mvc;
using BattleShip.Models;
using BattleShip.Services;
using BattleShip;

namespace BattleShipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private static GameManager _gameManager;

        [HttpPost("start")]
        public IActionResult StartGame([FromBody] int cellCount)
        {
            if (cellCount < 2 || cellCount > 100)
            {
                return BadRequest("Please enter a valid number (greater than 1 and less or equal to 100).");
            }

            var humanPlayer = new HumanPlayer();
            var computerPlayer = new ComputerPlayer();
            _gameManager = new GameManager(cellCount, humanPlayer, computerPlayer);
            _gameManager.StartGame();
            return Ok("Game started!");
        }

        [HttpPost("move")]
        public IActionResult MakeMove([FromBody] int position)
        {
            if (_gameManager == null)
            {
                return BadRequest("Game not started.");
            }

            var result = _gameManager.MakeMove(position);
            return Ok(result);
        }

        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            if (_gameManager == null)
            {
                return BadRequest("Game not started.");
            }

            var (playerBoard, computerBoard, lastPlayerMove, lastComputerMove) = _gameManager.GetGameStatus();
            return Ok(new
            {
                PlayerBoard = playerBoard.GetCells(),
                ComputerBoard = computerBoard.GetCells(),
                LastPlayerMove = lastPlayerMove,
                LastComputerMove = lastComputerMove
            });
        }
    }
}
