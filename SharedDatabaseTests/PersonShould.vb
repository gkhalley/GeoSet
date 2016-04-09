Imports System.Data.Entity
Imports EngineeringOffice.SharedDatabase.DAL
Imports EngineeringOffice.SharedDatabase.Models
Imports Ploeh.AutoFixture.Xunit2
Imports Xunit
Imports ManageOps.SharedKernel

<Trait("Category", "Person should")>
Public Class PersonShould
    <Fact, AutoData>
    Public Sub AutoDataTypes(a As String, p As Company)
        Assert.True(True)
    End Sub

    <Theory, InlineAutoData(42), InlineAutoData>
    Public Sub BeAnEntity()
        Dim person = New Person(Guid.NewGuid())
        Assert.IsType(GetType(person), GetType(DbSet))
    End Sub
    Protected Sub Seed(context As EngineeringOfficeContext)
        Dim company = New Company With {.Address = "46 Grits Trail",
                .City = "Long Lane",
                .Country = "USA",
                .Name = "KLH Engineering, LLC",
                .PostalCode = "65590",
                .ProvinceStateCode = "MO"}
        context.Company.Add(company)
    End Sub
End Class