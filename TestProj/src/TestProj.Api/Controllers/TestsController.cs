using Microsoft.AspNetCore.Mvc;
using TestProj.Api.Models;

namespace TestProj.Api.Controllers;

[Route("api/tests")]
[ApiController]
public class TestsController : ControllerBase
{
    private static List<Test> Tests;

    public TestsController()
    {
        Tests = new List<Test>()
        {
            new Test()
            {
                TestId = Guid.NewGuid(),
                Title = "Sample Test 1",
                Question = "What is the capital of France?"
            },
            new Test() 
            {
                TestId = Guid.NewGuid(),
                Title = "Sample Test 2",
                Question = "What is 2 + 2?" 
            }};
    }

    [HttpGet]
    public List<Test> GetTests()
    {
        return Tests;
    }

    [HttpPost]
    public Guid CreateTest([FromBody] TestCreate test)
    {
        Test newTest = new Test
        {
            TestId = Guid.NewGuid(),
            Title = test.Title,
            Question = test.Question
        };

        Tests.Add(newTest);
        return newTest.TestId;
    }
}
