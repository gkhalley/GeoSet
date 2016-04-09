<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:kml="http://www.opengis.net/kml/2.2">
  <xsl:output indent="yes" method="xml" cdata-section-elements="Description" />
  <xsl:template match="/">
    <xsl:element name="Document">
      <xsl:element name="name">
        <xsl:value-of select="kml:kml/kml:Document/kml:name" />
      </xsl:element>
      <xsl:element name="Folders">
        <xsl:apply-templates select="//kml:Folder" />
      </xsl:element>
      <xsl:element name="Geometries">
        <xsl:apply-templates select="//kml:Placemark" />
      </xsl:element>
      <xsl:element name="Styles">
        <xsl:apply-templates select="/kml:kml/kml:Document/kml:Style" />
      </xsl:element>
      <xsl:element name="StyleMaps">
        <xsl:apply-templates select="/kml:kml/kml:Document/kml:StyleMap" />
      </xsl:element>
    </xsl:element>
  </xsl:template>
  <xsl:template match="//kml:Folder">
    <xsl:element name="Folder">
      <xsl:element name="FolderID">
        <xsl:value-of select="generate-id(.)" />
      </xsl:element>
      <xsl:element name="name">
        <xsl:value-of select="./kml:name" />
      </xsl:element>
      <xsl:element name="ParentFolderID">
        <xsl:value-of select="generate-id(ancestor::kml:Folder[1])" />
      </xsl:element>
    </xsl:element>
  </xsl:template>
  <xsl:template match="/kml:kml/kml:Document/kml:Style">
    <xsl:element name="Style">
      <xsl:element name="Style_id">
        <xsl:value-of select="@id" />
      </xsl:element>
      <xsl:element name="color">
        <xsl:value-of select="kml:IconStyle/kml:color" />
      </xsl:element>
      <xsl:element name="scale">
        <xsl:value-of select="kml:IconStyle/kml:scale" />
      </xsl:element>
      <xsl:element name="Icon">
        <xsl:value-of select="kml:IconStyle/kml:Icon/kml:href" />
      </xsl:element>
      <xsl:element name="hotSpotx">
        <xsl:value-of select="kml:IconStyle/kml:hotSpot/@x" />
      </xsl:element>
      <xsl:element name="hotSpoty">
        <xsl:value-of select="kml:IconStyle/kml:hotSpot/@y" />
      </xsl:element>
      <xsl:element name="hotSpotxunits">
        <xsl:value-of select="kml:IconStyle/kml:hotSpot/@xunits" />
      </xsl:element>
      <xsl:element name="hotSpotyunits">
        <xsl:value-of select="kml:IconStyle/kml:hotSpot/@yunits" />
      </xsl:element>
      <xsl:element name="LineStyle_color">
        <xsl:value-of select="kml:LineStyle/kml:color" />
      </xsl:element>
      <xsl:element name="LineStyle_width">
        <xsl:value-of select="kml:LineStyle/kml:width" />
      </xsl:element>
      <xsl:element name="LabelStyle_scale">
        <xsl:value-of select="kml:LabelStyle/kml:scale" />
      </xsl:element>
    </xsl:element>
  </xsl:template>
  <xsl:template match="/kml:kml/kml:Document/kml:StyleMap">
    <xsl:element name="StyleMap">
      <xsl:element name="id">
        <xsl:value-of select="@id" />
      </xsl:element>
      <xsl:element name="chrKey1">
        <xsl:value-of select="kml:Pair[1]/kml:key" />
      </xsl:element>
      <xsl:element name="chrStyleUrl1">
        <xsl:value-of select="kml:Pair[1]/kml:styleUrl" />
      </xsl:element>
      <xsl:element name="chrKey2">
        <xsl:value-of select="kml:Pair[2]/kml:key" />
      </xsl:element>
      <xsl:element name="chrStyleUrl2">
        <xsl:value-of select="kml:Pair[2]/kml:styleUrl" />
      </xsl:element>
    </xsl:element>
  </xsl:template>
  <xsl:template
    match="kml:MultiGeometry/kml:Polygon/kml:outerBoundaryIs/kml:LinearRing|kml:Polygon/kml:outerBoundaryIs/kml:LinearRing">
    <xsl:element name="chrType">
      <xsl:text>POLYGON</xsl:text>
    </xsl:element>
    <xsl:element name="coordinates">
      <xsl:value-of select="normalize-space(./kml:coordinates)" />
    </xsl:element>
  </xsl:template>
  <xsl:template match="kml:MultiGeometry/kml:LineString|kml:LineString">
    <xsl:element name="chrType">
      <xsl:text>LINESTRING</xsl:text>
    </xsl:element>
    <xsl:element name="coordinates">
      <xsl:value-of select="normalize-space(./kml:coordinates)" />
    </xsl:element>
  </xsl:template>
  <xsl:template match="kml:Point">
    <xsl:element name="chrType">
      <xsl:text>POINT</xsl:text>
    </xsl:element>
    <xsl:element name="coordinates">
      <xsl:value-of select="normalize-space(./kml:coordinates)" />
    </xsl:element>
  </xsl:template>
  <xsl:template match="//kml:Placemark">
    <xsl:element name="Geometry">
      <xsl:element name="name">
        <xsl:value-of select="kml:name" />
      </xsl:element>
      <xsl:element name="id">
        <xsl:value-of select="@id" />
      </xsl:element>
      <xsl:element name="styleUrl">
        <xsl:value-of select="kml:styleUrl" />
      </xsl:element>
      <xsl:element name="Description">
        <xsl:text disable-output-escaping="yes">&lt;![CDATA[</xsl:text>
        <xsl:value-of disable-output-escaping="yes" select="kml:description" />
        <xsl:text disable-output-escaping="yes">]]&gt;</xsl:text>
      </xsl:element>
      <xsl:element name="FolderID">
        <xsl:value-of select="generate-id(ancestor::kml:Folder[1])" />
      </xsl:element>
      <xsl:apply-templates select="kml:MultiGeometry/kml:LineString|kml:LineString" />
      <xsl:apply-templates
        select="kml:MultiGeometry/kml:Polygon/kml:outerBoundaryIs/kml:LinearRing|kml:Polygon/kml:outerBoundaryIs/kml:LinearRing" />
      <xsl:apply-templates select="kml:Point" />
    </xsl:element>
  </xsl:template>
</xsl:stylesheet>