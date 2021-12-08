<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/412034304/21.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1033229)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Gantt for Web Forms - Planned vs actual tasks  

This example demonstrates how to display both actual and planned tasks in the Gantt chart area.

The Gantt data source contains [four date fields]./CS/DXWebApplication1/App_Data/GanttDataProvider.cs): two of them contain planned dates for a task and the other two are filled based on real dates of each task.

The client-side [TaskShowing](https://docs.devexpress.com/AspNet/js-ASPxClientGantt.TaskShowing) event is used to display two visual elements for one task.


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

The main idea is to create two HTML div elements and add them to a task container. The first element represents [planned](./CS/DXWebApplication1/Default.aspx#L21) tasks. It is created based on the taskSize parameter. The taskSize parameter comes from the  [e.item.taskSize.width](https://docs.devexpress.com/AspNet/js-ASPxClientGanttTaskShowingEventArgs.item) property of the [TaskShowing](https://docs.devexpress.com/AspNet/js-ASPxClientGantt.TaskShowing) event.

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

The second element is for an actual task. Its size and position are [calculated](.//CS/DXWebApplication1/Default.aspx) based on task data. The task data contains the StartDate, EndDate, ActualStartDate, and ActualEndDate that are used to calculate the position of the actual task. The task data comes from the [e.item.taskData](https://docs.devexpress.com/AspNet/js-ASPxClientGanttTaskShowingEventArgs.item) property of the [TaskShowing](https://docs.devexpress.com/AspNet/js-ASPxClientGantt.TaskShowing) event.

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
