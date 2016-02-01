<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:students="urn:students"
>
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/">
    <html>
      <body>
        <h2>Students</h2>
        <br></br>
        <table border="1">
          <tr bgcolor="#9acd32">
            <th style="text-align:left">Name</th>
            <th style="text-align:left">Gender</th>
            <th style="text-align:left">Birthdate</th>
            <th style="text-align:left">Phone</th>
            <th style="text-align:left">Email</th>
            <th style="text-align:left">University</th>
            <th style="text-align:left">Specialty</th>
            <th style="text-align:left">Faculty Number</th>
            <th style="text-align:left">Exams</th>
          </tr>
          <xsl:for-each select="/students/students:student">
            <tr>
              <td>
                <xsl:value-of select="students:name"/>
              </td>
              <td>
                <xsl:value-of select="students:gender"/>
              </td>
              <td>
                <xsl:value-of select="students:birthdate"/>
              </td>
              <td>
                <xsl:value-of select="students:phone"/>
              </td>
              <td>
                <xsl:value-of select="students:email"/>
              </td>
              <td>
                <xsl:value-of select="students:university"/>
              </td>
              <td>
                <xsl:value-of select="students:specialty"/>
              </td>
              <td>
                <xsl:value-of select="students:faculty-number"/>
              </td>
              <td>
                <xsl:value-of select="students:exams"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
