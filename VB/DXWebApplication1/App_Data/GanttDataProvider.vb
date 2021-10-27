Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.SessionState

Namespace DXWebApplication1

    Public Module GanttDataProvider

        Const TasksSessionKey As String = "Tasks1", DependenciesSessionKey As String = "Dependencies1", ResourcesSessionKey As String = "Resources1", ResourceAssignmentsSessionKey As String = "ResourceAssignments1"

        Private ReadOnly Property Session As HttpSessionState
            Get
                Return HttpContext.Current.Session
            End Get
        End Property

        Public Function GetTasks() As Object
            Return Tasks
        End Function

        Public Function GetDependencies() As Object
            Return Dependencies
        End Function

        Public Function GetResources() As Object
            Return Resources
        End Function

        Public Function GetResourceAssignments() As Object
            Return ResourceAssignments
        End Function

        Public ReadOnly Property Tasks As List(Of Task)
            Get
                If Session(TasksSessionKey) Is Nothing Then Session(TasksSessionKey) = CreateTasks()
                Return CType(Session(TasksSessionKey), List(Of Task))
            End Get
        End Property

        Public ReadOnly Property Dependencies As List(Of Dependency)
            Get
                If Session(DependenciesSessionKey) Is Nothing Then Session(DependenciesSessionKey) = CreateDependencies()
                Return CType(Session(DependenciesSessionKey), List(Of Dependency))
            End Get
        End Property

        Public ReadOnly Property Resources As List(Of Resource)
            Get
                If Session(ResourcesSessionKey) Is Nothing Then Session(ResourcesSessionKey) = CreateResources()
                Return CType(Session(ResourcesSessionKey), List(Of Resource))
            End Get
        End Property

        Public ReadOnly Property ResourceAssignments As List(Of ResourceAssignment)
            Get
                If Session(ResourceAssignmentsSessionKey) Is Nothing Then Session(ResourceAssignmentsSessionKey) = CreateResourceAssignments()
                Return CType(Session(ResourceAssignmentsSessionKey), List(Of ResourceAssignment))
            End Get
        End Property

        Private Function CreateTasks() As List(Of Task)
            Dim result = New List(Of Task)()
            result.Add(CreateTask("0", Nothing, "Software Development", "02/21/2021 08:00:00", "03/15/2021 15:00:00", "02/21/2021 08:00:00", "03/25/2021 12:00:00", "31", "1", "0", "", ""))
            result.Add(CreateTask("1", "0", "Scope", "02/21/2021 08:00:00", "02/26/2021 12:00:00", "02/23/2021 00:00:00", "03/01/2021 00:00:00", "60", "1", "1", "", ""))
            result.Add(CreateTask("2", "1", "Determine project scope", "02/22/2021 08:00:00", "02/24/2021 12:00:00", "02/24/2021 00:00:00", "02/28/2021 00:00:00", "100", "1", "2", "1", "Important"))
            result.Add(CreateTask("3", "1", "Secure project sponsorship", "02/22/2021 13:00:00", "02/23/2021 12:00:00", "02/22/2021 08:00:00", "02/24/2021 00:00:00", "100", "1", "2", "1", ""))
            result.Add(CreateTask("4", "1", "Define preliminary resources", "02/22/2021 13:00:00", "02/26/2021 12:00:00", "02/21/2021 13:00:00", "02/25/2021 00:00:00", "60", "1", "2", "2", ""))
            result.Add(CreateTask("5", "1", "Secure core resources", "02/25/2021 13:00:00", "02/26/2021 12:00:00", "02/27/2021 00:00:00", "02/28/2021 12:00:00", "0", "1", "2", "2", ""))
            result.Add(CreateTask("6", "1", "Scope complete", "02/26/2021 12:00:00", "02/27/2021 12:00:00", "02/27/2021 12:00:00", "03/1/2021 12:00:00", "0", "0", "2", "", "Important"))
            result.Add(CreateTask("7", "0", "Analysis/Software Requirements", "02/26/2021 13:00:00", "03/18/2021 12:00:00", "02/27/2021 00:00:00", "03/21/2021 00:00:00", "80", "1", "1", "", "Important"))
            result.Add(CreateTask("8", "7", "Conduct needs analysis", "02/26/2021 13:00:00", "03/05/2021 12:00:00", "02/24/2021 13:00:00", "03/02/2021 00:00:00", "100", "1", "2", "3", ""))
            result.Add(CreateTask("9", "7", "Draft preliminary software specifications", "03/05/2021 13:00:00", "03/08/2021 12:00:00", "03/08/2021 08:00:00", "03/11/2021 00:00:00", "100", "1", "2", "3", ""))
            result.Add(CreateTask("10", "7", "Develop preliminary budget", "03/08/2021 13:00:00", "03/12/2021 12:00:00", "03/07/2021 13:00:00", "03/10/2021 00:00:00", "100", "1", "2", "2", ""))
            result.Add(CreateTask("11", "7", "Review software specifications/budget with team", "03/12/2021 13:00:00", "03/14/2021 17:00:00", "03/13/2021 17:00:00", "03/16/2021 00:00:00", "100", "1", "2", "2,3", ""))
            result.Add(CreateTask("12", "7", "Incorporate feedback on software specifications", "03/13/2021 08:00:00", "03/19/2021 17:00:00", "03/15/2021 08:00:00", "03/23/2021 17:00:00", "70", "1", "2", "3", ""))
            result.Add(CreateTask("13", "7", "Develop delivery timeline", "03/14/2021 08:00:00", "03/14/2021 17:00:00", "03/14/2021 08:00:00", "03/16/2021 10:00:00", "0", "1", "2", "2", ""))
            result.Add(CreateTask("14", "7", "Obtain approvals to proceed (concept, timeline, budget)", "03/15/2021 08:00:00", "03/15/2021 12:00:00", "03/15/2021 08:00:00", "03/16/2021 12:00:00", "0", "1", "2", "1,2", ""))
            result.Add(CreateTask("15", "14", "Secure required resources", "03/15/2021 13:00:00", "03/18/2021 12:00:00", "03/18/2021 13:00:00", "03/25/2021 12:00:00", "0", "1", "2", "2", ""))
            Return result
        End Function

        Public Function CreateTask(ByVal key As String, ByVal parentkey As String, ByVal title As String, ByVal start As String, ByVal [end] As String, ByVal actualstart As String, ByVal actualEnd As String, ByVal percent As String, ByVal type As String, ByVal status As String, ByVal resources As String, ByVal description As String) As Task
            Dim task = New Task()
            task.Key = key
            task.ParentKey = parentkey
            task.Title = title
            task.StartDate = Date.Parse(start, Globalization.CultureInfo.InvariantCulture)
            task.EndDate = Date.Parse([end], Globalization.CultureInfo.InvariantCulture)
            task.ActualStartDate = Date.Parse(actualstart, Globalization.CultureInfo.InvariantCulture)
            task.ActualEndDate = Date.Parse(actualEnd, Globalization.CultureInfo.InvariantCulture)
            task.Progress = Convert.ToInt32(percent)
            task.Resources = resources
            task.Description = description
            Return task
        End Function

        Private Function CreateDependencies() As List(Of Dependency)
            Dim result = New List(Of Dependency)()
            For i As Integer = 0 To Tasks.Count - 1
                Dim task As Task = Tasks(i)
                If Not String.IsNullOrEmpty(task.ParentKey) AndAlso Not Equals(task.ParentKey, "-1") Then
                    result.Add(New Dependency() With {.Key = CreateUniqueId(), .Type = 0, .PredecessorKey = Tasks(i - 1).Key, .SuccessorKey = task.Key})
                End If
            Next

            Return result
        End Function

        Private Function CreateResources() As List(Of Resource)
            Dim result = New List(Of Resource)()
            result.Add(New Resource() With {.Key = "1", .Name = "Management"})
            result.Add(New Resource() With {.Key = "2", .Name = "Project Manager"})
            result.Add(New Resource() With {.Key = "3", .Name = "Analyst"})
            result.Add(New Resource() With {.Key = "4", .Name = "Developer"})
            result.Add(New Resource() With {.Key = "5", .Name = "Testers"})
            result.Add(New Resource() With {.Key = "6", .Name = "Trainers"})
            result.Add(New Resource() With {.Key = "7", .Name = "Technical Communicators"})
            result.Add(New Resource() With {.Key = "8", .Name = "Deployment Team"})
            Return result
        End Function

        Private Function CreateResourceAssignments() As List(Of ResourceAssignment)
            Dim result = New List(Of ResourceAssignment)()
            For Each task As Task In Tasks
                If Not String.IsNullOrEmpty(task.Resources) Then
                    Dim resourcesID As String() = task.Resources.Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries)
                    For i As Integer = 0 To resourcesID.Length - 1
                        result.Add(New ResourceAssignment() With {.Key = CreateUniqueId(), .TaskKey = task.Key, .ResourceKey = resourcesID(i)})
                    Next
                End If
            Next

            Return result
        End Function

        Private Function CreateUniqueId() As String
            Return Guid.NewGuid().ToString()
        End Function
    End Module

    Public Class Task

        Public Property Key As String

        Public Property ParentKey As String

        Public Property Title As String

        Public Property Description As String

        Public Property StartDate As Date

        Public Property EndDate As Date

        Public Property ActualStartDate As Date

        Public Property ActualEndDate As Date

        Public Property Progress As Integer

        Public Property Resources As String
    End Class

    Public Class Dependency

        Public Property Key As String

        Public Property PredecessorKey As String

        Public Property SuccessorKey As String

        Public Property Type As Integer
    End Class

    Public Class Resource

        Public Property Key As String

        Public Property Name As String
    End Class

    Public Class ResourceAssignment

        Public Property Key As String

        Public Property TaskKey As String

        Public Property ResourceKey As String
    End Class
End Namespace
