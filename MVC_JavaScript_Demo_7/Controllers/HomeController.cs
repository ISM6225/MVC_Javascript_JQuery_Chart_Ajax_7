using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_JavaScript_Demo_7.Models;

namespace MVC_JavaScript_Demo_7.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult IndexWithLayout()
    {
        return View();
    }

    /// <summary>
    /// Replicate the chart example in the JavaScript presentation
    /// 
    /// Typically LINQ and SQL return data as collections.
    /// Hence we start the example by creating collections representing the x-axis labels and the y-axis values
    /// However, chart.js expects data as a string, not as a collection.
    ///   Hence we join the elements in the collections into strings in the view model
    /// </summary>
    /// <returns>View that will display the chart</returns>
    public ViewResult DemoChart()
    {
        string[] ChartLabels = new string[] { "Africa", "Asia", "Europe", "Latin America", "North America" };
        string[] ChartColors = new string[] { "#3e95cd", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850" };
        int[] ChartData = new int[] { 2478, 5267, 734, 784, 433 };

        ChartModel Model = new ChartModel
        {
            ChartType = "bar",
            Labels = String.Join(",", ChartLabels.Select(d => "'" + d + "'")),
            Colors = String.Join(",", ChartColors.Select(d => "\"" + d + "\"")),
            Data = String.Join(",", ChartData.Select(d => d)),
            Title = "Predicted world population (millions) in 2050"
        };

        return View(Model);
    }

    public ViewResult DemoAjax()
    {
        return View();
    }

    public JsonResult AjaxResult()
    {
        Task.WaitAll(Task.Delay(1000));

        return Json("Test");

    }
}
