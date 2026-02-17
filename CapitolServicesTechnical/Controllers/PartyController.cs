using Microsoft.AspNetCore.Mvc;
using CapitolServicesTechnical.Models;

namespace CapitolServicesTechnical.Controllers;

public class PartyController : Controller
{
    // A static list should be fine for our needs. It does mean that 
    // all users will see each other's additions to the party until app restart, 
    // but hey...The more the merrier.
    private static readonly List<PartyMember> _partyMembers = new()
    {
        new PartyMember { Id = 1, Name = "Cecil", Class = "Paladin", Level = 23 },
        new PartyMember { Id = 2, Name = "Kain", Class = "Dragoon", Level = 18 },
        new PartyMember { Id = 3, Name = "Rydia", Class = "Summoner", Level = 24 },
        new PartyMember { Id = 4, Name = "Rosa", Class = "Cleric", Level = 21 },
        new PartyMember { Id = 5, Name = "Edge", Class = "Ninja", Level = 21 }
    };
    private static int _nextId = 6;

    [HttpGet]
    [Route("Party")]
    public IActionResult Index()
    {
        return View(_partyMembers);
    }

    [HttpPost]
    [Route("Party/Add")]
    public IActionResult AddMember(string name, string className, int level)
    {
        // Naturally if this were something going to production, we'd want to validate some 
        // of these inputs for security reasons.
        var newMember = new PartyMember
        {
            Id = _nextId++,
            Name = name,
            Class = className,
            Level = level
        };

        _partyMembers.Add(newMember);

        return RedirectToAction(nameof(Index));
    }
}
