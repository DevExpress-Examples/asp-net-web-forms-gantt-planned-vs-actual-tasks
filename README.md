<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/412034304/21.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1033229)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Gantt for Web Forms - Planned vs actual tasks  

This example demonstrates how to display both actual and planned tasks in the Gantt chart area.

The Gantt data source contains [four date fields](https://github.com/DevExpress-Examples/gantt-for-web-forms-planned-vs-actual-tasks/blob/21.1.3%2B/CS/DXWebApplication1/App_Data/GanttDataProvider.cs): two of them contain planned dates for a task and the other two are filled based on real dates of each task.

The client-side [TaskShowing](https://docs.devexpress.com/AspNet/js-ASPxClientGantt.TaskShowing) event is used to display two visual elements for one task.

The main idea is to create two HTML div elements and add them to a task container. The first element represents [planned](https://github.com/DevExpress-Examples/gantt-for-java-script-planned-vs-actual-tasks/blob/21.1.4+/CS/DevExtremeMvcApp1/Views/Home/Index.cshtml#L75) tasks. It is created based on the taskSize parameter.

The second element is for an actual task. Its size and position are [calculated](.//CS/DXWebApplication1/Default.aspx) based on task data. Appearance of actual tasks is defined by the [actual-task](https://github.com/DevExpress-Examples/gantt-for-web-forms-planned-vs-actual-tasks/blob/21.1.3%2B/CS/DXWebApplication1/Default.aspxl#L25) class. 

<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/DXWebApplication1/Default.aspx)
* [Default.aspx.cs](./CS/DXWebApplication1/Default.aspx.cs)
* [GanttDataProvider.cs](.CS/DXWebApplication1/App_Data/GanttDataProvider.cs)
<!-- default file list end -->
