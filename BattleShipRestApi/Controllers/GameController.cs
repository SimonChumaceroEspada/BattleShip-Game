using Microsoft.AspNetCore.Mvc;
using BattleShip.Models;
using BattleShip.Services;
using BattleShip;

namespace BattleShipRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private static GameManager _gameManager;
        private static Player _humanPlayer;

        [HttpPost("setup")]
        public IActionResult SetupGame([FromBody] int cellCount)
        {
            if (cellCount < 2 || cellCount > 100)
            {
                return BadRequest("Please enter a valid number (greater than 1 and less or equal to 100).");
            }

            _humanPlayer = new HumanPlayer();
            var computerPlayer = new ComputerPlayer();
            _gameManager = new GameManager(cellCount, _humanPlayer, computerPlayer);
            return Ok("Game setup complete! Now choose a cell to hide your ship.");
        }

        [HttpPost("place-ship")]
        public IActionResult PlaceShip([FromBody] int position)
        {
            if (_gameManager == null)
            {
                return BadRequest("Game not setup. Please setup the game first.");
            }

            if (position < 1 || position > _gameManager.CellCount)
            {
                return BadRequest($"Please choose a valid cell (1-{_gameManager.CellCount}).");
            }

            _humanPlayer.PlaceShip(_gameManager.CellCount, position);
            // Start the game once the players ship is placed
            _gameManager.StartGame();
            return Ok($"Ship placed at position {position}. Game started!");
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
