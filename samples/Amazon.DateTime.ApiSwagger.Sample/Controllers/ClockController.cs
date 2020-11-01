using Microsoft.AspNetCore.Mvc;

namespace Amazon.DateTime.ApiSwagger.Sample.Controllers
{
    [Route("clock")]
    public class ClockController : Controller
    {
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Clock), 200)]
        public IActionResult Index()
        {
            return Ok(new Clock());
        }
    }

    public class Clock
    {
        public Clock()
        {
            Universal = UniversalDateTime.Now;
            Eastern = EasternDateTime.Now;
            Central = CentralDateTime.Now;
            Mountain = MountainDateTime.Now;
            Pacific = PacificDateTime.Now;
            Alaska = AlaskaDateTime.Now;
            Hawaii = HawaiiDateTime.Now;
        }

        public UniversalDateTime Universal { get; }
        public EasternDateTime Eastern { get; }
        public CentralDateTime Central { get; }
        public MountainDateTime Mountain { get; }
        public PacificDateTime Pacific { get; }
        public AlaskaDateTime Alaska { get; }
        public HawaiiDateTime Hawaii { get; }
    }
}
