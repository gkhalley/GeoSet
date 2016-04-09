Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Reflection

'this base class comes from Jimmy Bogard
'http://grabbagoft.blogspot.com/2007/06/generic-value-object-equality.html

Namespace ManageOps.SharedKernel
    Public MustInherit Class ValueObject(Of T As ValueObject(Of T))
        Implements IEquatable(Of T)

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            If obj Is Nothing Then
                Return False
            End If

            Dim other As T = TryCast(obj, T)

            Return Equals(other)
        End Function

        Public Overrides Function GetHashCode() As Integer
            Dim fields As IEnumerable(Of FieldInfo) = GetFields()

            Dim startValue As Integer = 17
            Dim multiplier As Integer = 59

            Dim hashCode As Integer = startValue

            For Each field As FieldInfo In fields
                Dim value As Object = field.GetValue(Me)

                If value IsNot Nothing Then
                    hashCode = hashCode * multiplier + value.GetHashCode()
                End If
            Next field

            Return hashCode
        End Function

        Public Overridable Overloads Function Equals(ByVal other As T) As Boolean Implements IEquatable(Of T).Equals
            If other Is Nothing Then
                Return False
            End If

            Dim t As Type = Me.GetType()
            Dim otherType As Type = other.GetType()

            If t IsNot otherType Then
                Return False
            End If

            Dim fields() As FieldInfo = t.GetFields(BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public)

            For Each field As FieldInfo In fields
                Dim value1 As Object = field.GetValue(other)
                Dim value2 As Object = field.GetValue(Me)

                If value1 Is Nothing Then
                    If value2 IsNot Nothing Then
                        Return False
                    End If
                ElseIf Not value1.Equals(value2) Then
                    Return False
                End If
            Next field

            Return True
        End Function

        Private Function GetFields() As IEnumerable(Of FieldInfo)
            Dim t As Type = Me.GetType()

            Dim fields As New List(Of FieldInfo)()

            Do While t IsNot GetType(Object)
                fields.AddRange(t.GetFields(BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public))

                t = t.BaseType
            Loop

            Return fields
        End Function

        Public Shared Operator =(ByVal x As ValueObject(Of T), ByVal y As ValueObject(Of T)) As Boolean
            Return x.Equals(y)
        End Operator

        Public Shared Operator <>(ByVal x As ValueObject(Of T), ByVal y As ValueObject(Of T)) As Boolean
            Return Not (x Is y)
        End Operator
    End Class
End Namespace
