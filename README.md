<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/412034304/21.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1033229)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Gantt for Web Forms - Planned vs Actual Tasks  

This example demonstrates how to display actual and planned tasks in the Gantt chart.

The main idea of this example is to create two div elements and add them to a task's container. The first div element displays [planned](./CS/DXWebApplication1/Default.aspx#L21) tasks. The second div element is for [actual](./CS/DXWebApplication1/Default.aspx#L45) tasks.

![DevExpress Gantt - Planned vs Actual Tasks](~/images/gantt-planned-actual-tasks.png)

The data source with Gantt data contains [four date fields](./CS/DXWebApplication1/App_Data/GanttDataProvider.cs). Two date fields (startDate, endDate) contain planned dates for a task. The other two are actual task dates.

```csharp
public class Task
{
    //...
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime ActualStartDate { get; set; }
    public DateTime ActualEndDate { get; set; }
}
```

Handle the [TaskShowing](https://docs.devexpress.com/AspNet/js-ASPxClientGantt.TaskShowing) event to create two div elements and add them to a task's container (the e.container property).

```aspx
<dx:ASPxGantt ID="Gantt" runat="server" ...>
    <ClientSideEvents TaskShowing="getTaskContentTemplate" />
    ...
</dx:ASPxGantt>
```

```js
function getTaskContentTemplate(s, e) {
    var $parentContainer = $(document.createElement("div"));
    appendPlannedTask(e.item.taskData, e.item.taskResources[0], e.item.taskSize.width, $parentContainer);
    appendActualTask(e.item.taskData, e.item.taskSize.width, $parentContainer);
    $parentContainer.appendTo(e.container);
}
```

The first div element (planned task) uses the [e.item.taskSize.width](https://docs.devexpress.com/AspNet/js-ASPxClientGanttTaskShowingEventArgs.item) parameter as the element's width.

```js
function appendPlannedTask(taskData, resource, taskWidth, container) {
    var $plannedTaskContainer = $(document.createElement("div"))
        .addClass("planned-task")
        .attr("style", "width:" + taskWidth + "px;")
        .appendTo(container);
    var $wrapper = $(document.createElement("div"))
        .addClass("planned-task-wrapper")
        .appendTo($plannedTaskContainer);
    $(document.createElement("div"))
        .addClass("planned-task-title")
        .text(taskData.Title)
        .appendTo($wrapper);
    $(document.createElement("div"))
        .addClass("planned-task-resource")
        .text(resource ? resource.text : "")
        .appendTo($wrapper);
    $(document.createElement("div"))
        .addClass("planned-task-progress")
        .attr("style", "width:" + (parseFloat(taskData.Progress)) + "%;")
        .appendTo($plannedTaskContainer);
}
```

The second div element (actual task) calculates its width and position based on the StartDate, EndDate, ActualStartDate, and ActualEndDate properties from the [e.item.taskData](https://docs.devexpress.com/AspNet/js-ASPxClientGanttTaskShowingEventArgs.item) object. 

```js
function appendActualTask(taskData, taskWidth, container) {
    var taskRange = taskData.EndDate - taskData.StartDate;
    var tickSize = taskWidth / taskRange;
    var actualTaskOffset = new Date(taskData.ActualStartDate) - taskData.StartDate;
    var actualTaskRange = new Date(taskData.ActualEndDate) - new Date(taskData.ActualStartDate);
    var actualTaskWidth = Math.round(actualTaskRange * tickSize) + "px";
    var actualTaskLeftPosition = Math.round(actualTaskOffset * tickSize) + "px";
    $(document.createElement("div"))
        .addClass("actual-task")
        .attr("style", "width:" + actualTaskWidth + "; left:" + actualTaskLeftPosition)
        .appendTo(container);
}
```

<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/DXWebApplication1/Default.aspx)
* [GanttDataProvider.cs](./CS/DXWebApplication1/App_Data/GanttDataProvider.cs)
* [GanttDataProvider.vb](./VB/DXWebApplication1/App_Data/GanttDataProvider.vb)
<!-- default file list end -->
