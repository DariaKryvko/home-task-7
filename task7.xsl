<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="yes" encoding="utf-8"/>

  <xsl:template match="/MyRoot">
    <html>
      <head>
        <meta charset="utf-8"/>
        <title>MyRoot</title>
      </head>
      <body>
        <h2>MyRoot</h2>
        <table border="2">
          <tr>
            <th>ID (MyChild)</th>
            <th>NAME (MyGrandChild)</th>
          </tr>
          <xsl:apply-templates select="MyChild"/>
        </table>
      </body>
    </html>
  </xsl:template>

  <xsl:template match="MyChild">
    <tr>
      <td><b><xsl:value-of select="@ID"/></b></td>
      <td>
        <xsl:for-each select="MyGrandChild">
          <p><xsl:value-of select="@NAME"/></p>
        </xsl:for-each>
      </td>
    </tr>
  </xsl:template>
</xsl:stylesheet>