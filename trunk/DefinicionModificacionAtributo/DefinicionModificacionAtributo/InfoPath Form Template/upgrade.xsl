<?xml version="1.0" encoding="UTF-8" standalone="no"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:my="http://schemas.microsoft.com/office/infopath/2003/myXSD/2009-10-31T16:45:27" xmlns:xd="http://schemas.microsoft.com/office/infopath/2003" version="1.0">
	<xsl:output encoding="UTF-8" method="xml"/>
	<xsl:template match="/">
		<xsl:copy-of select="processing-instruction() | comment()"/>
		<xsl:choose>
			<xsl:when test="my:misCampos">
				<xsl:apply-templates select="my:misCampos" mode="_0"/>
			</xsl:when>
			<xsl:otherwise>
				<xsl:variable name="var">
					<xsl:element name="my:misCampos"/>
				</xsl:variable>
				<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_0"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
	<xsl:template match="my:InformacionGeneral" mode="_1">
		<xsl:copy>
			<xsl:element name="my:identificador">
				<xsl:choose>
					<xsl:when test="my:identificador/text()[1]">
						<xsl:copy-of select="my:identificador/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:autor">
				<xsl:copy-of select="my:autor/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:version">
				<xsl:choose>
					<xsl:when test="my:version/text()[1]">
						<xsl:copy-of select="my:version/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:fechaCreacion">
				<xsl:copy-of select="my:fechaCreacion/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:fechavigenciadesde">
				<xsl:copy-of select="my:fechavigenciadesde/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:fechavigenciahasta">
				<xsl:copy-of select="my:fechavigenciahasta/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:nombre">
				<xsl:copy-of select="my:nombre/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:descripcion">
				<xsl:copy-of select="my:descripcion/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:esModificable">
				<xsl:choose>
					<xsl:when test="my:esModificable">
						<xsl:copy-of select="my:esModificable/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>true</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="my:grupo7" mode="_4">
		<xsl:copy>
			<xsl:element name="my:campo1">
				<xsl:copy-of select="my:campo1/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:campo2">
				<xsl:copy-of select="my:campo2/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:campo3">
				<xsl:copy-of select="my:campo3/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:campo4">
				<xsl:copy-of select="my:campo4/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:campo5">
				<xsl:copy-of select="my:campo5/text()[1]"/>
			</xsl:element>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="my:grupo6" mode="_3">
		<xsl:copy>
			<xsl:choose>
				<xsl:when test="my:grupo7">
					<xsl:apply-templates select="my:grupo7" mode="_4"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="my:grupo7"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_4"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="my:observaciones" mode="_2">
		<xsl:copy>
			<xsl:choose>
				<xsl:when test="my:grupo6">
					<xsl:apply-templates select="my:grupo6[1]" mode="_3"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="my:grupo6"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_3"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="my:misCampos" mode="_0">
		<xsl:copy>
			<xsl:element name="my:grupo1"/>
			<xsl:choose>
				<xsl:when test="my:InformacionGeneral">
					<xsl:apply-templates select="my:InformacionGeneral[1]" mode="_1"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="my:InformacionGeneral"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_1"/>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:if test="my:grupo4">
				<xsl:element name="my:grupo4"/>
			</xsl:if>
			<xsl:element name="my:grupo5"/>
			<xsl:element name="my:informacionAgrupacion"/>
			<xsl:choose>
				<xsl:when test="my:observaciones">
					<xsl:apply-templates select="my:observaciones[1]" mode="_2"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="my:observaciones"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_2"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:copy>
	</xsl:template>
</xsl:stylesheet>