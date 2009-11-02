<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:my="http://schemas.microsoft.com/office/infopath/2003/myXSD/2009-10-31T16:45:27" xmlns:xd="http://schemas.microsoft.com/office/infopath/2003" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns:xdExtension="http://schemas.microsoft.com/office/infopath/2003/xslt/extension" xmlns:xdXDocument="http://schemas.microsoft.com/office/infopath/2003/xslt/xDocument" xmlns:xdSolution="http://schemas.microsoft.com/office/infopath/2003/xslt/solution" xmlns:xdFormatting="http://schemas.microsoft.com/office/infopath/2003/xslt/formatting" xmlns:xdImage="http://schemas.microsoft.com/office/infopath/2003/xslt/xImage" xmlns:xdUtil="http://schemas.microsoft.com/office/infopath/2003/xslt/Util" xmlns:xdMath="http://schemas.microsoft.com/office/infopath/2003/xslt/Math" xmlns:xdDate="http://schemas.microsoft.com/office/infopath/2003/xslt/Date" xmlns:sig="http://www.w3.org/2000/09/xmldsig#" xmlns:xdSignatureProperties="http://schemas.microsoft.com/office/infopath/2003/SignatureProperties" xmlns:ipApp="http://schemas.microsoft.com/office/infopath/2006/XPathExtension/ipApp" xmlns:xdEnvironment="http://schemas.microsoft.com/office/infopath/2006/xslt/environment" xmlns:xdUser="http://schemas.microsoft.com/office/infopath/2006/xslt/User">
	<xsl:output method="html" indent="no"/>
	<xsl:template match="my:misCampos">
		<html>
			<head>
				<meta content="text/html" http-equiv="Content-Type"></meta>
				<style controlStyle="controlStyle">@media screen 			{ 			BODY{margin-left:21px;background-position:21px 0px;} 			} 		BODY{color:windowtext;background-color:window;layout-grid:none;} 		.xdListItem {display:inline-block;width:100%;vertical-align:text-top;} 		.xdListBox,.xdComboBox{margin:1px;} 		.xdInlinePicture{margin:1px; BEHAVIOR: url(#default#urn::xdPicture) } 		.xdLinkedPicture{margin:1px; BEHAVIOR: url(#default#urn::xdPicture) url(#default#urn::controls/Binder) } 		.xdSection{border:1pt solid #FFFFFF;margin:6px 0px 6px 0px;padding:1px 1px 1px 5px;} 		.xdRepeatingSection{border:1pt solid #FFFFFF;margin:6px 0px 6px 0px;padding:1px 1px 1px 5px;} 		.xdMultiSelectList{margin:1px;display:inline-block; border:1pt solid #dcdcdc; padding:1px 1px 1px 5px; text-indent:0; color:windowtext; background-color:window; overflow:auto; behavior: url(#default#DataBindingUI) url(#default#urn::controls/Binder) url(#default#MultiSelectHelper) url(#default#ScrollableRegion);} 		.xdMultiSelectListItem{display:block;white-space:nowrap}		.xdMultiSelectFillIn{display:inline-block;white-space:nowrap;text-overflow:ellipsis;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;overflow:hidden;text-align:left;}		.xdBehavior_Formatting {BEHAVIOR: url(#default#urn::controls/Binder) url(#default#Formatting);} 	 .xdBehavior_FormattingNoBUI{BEHAVIOR: url(#default#CalPopup) url(#default#urn::controls/Binder) url(#default#Formatting);} 	.xdExpressionBox{margin: 1px;padding:1px;word-wrap: break-word;text-overflow: ellipsis;overflow-x:hidden;}.xdBehavior_GhostedText,.xdBehavior_GhostedTextNoBUI{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#TextField) url(#default#GhostedText);}	.xdBehavior_GTFormatting{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#Formatting) url(#default#GhostedText);}	.xdBehavior_GTFormattingNoBUI{BEHAVIOR: url(#default#CalPopup) url(#default#urn::controls/Binder) url(#default#Formatting) url(#default#GhostedText);}	.xdBehavior_Boolean{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#BooleanHelper);}	.xdBehavior_Select{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#SelectHelper);}	.xdBehavior_ComboBox{BEHAVIOR: url(#default#ComboBox)} 	.xdBehavior_ComboBoxTextField{BEHAVIOR: url(#default#ComboBoxTextField);} 	.xdRepeatingTable{BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word;}.xdScrollableRegion{BEHAVIOR: url(#default#ScrollableRegion);} 		.xdLayoutRegion{display:inline-block;} 		.xdMaster{BEHAVIOR: url(#default#MasterHelper);} 		.xdActiveX{margin:1px; BEHAVIOR: url(#default#ActiveX);} 		.xdFileAttachment{display:inline-block;margin:1px;BEHAVIOR:url(#default#urn::xdFileAttachment);} 		.xdPageBreak{display: none;}BODY{margin-right:21px;} 		.xdTextBoxRTL{display:inline-block;white-space:nowrap;text-overflow:ellipsis;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;text-align:right;word-wrap:normal;} 		.xdRichTextBoxRTL{display:inline-block;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow-x:hidden;word-wrap:break-word;text-overflow:ellipsis;text-align:right;font-weight:normal;font-style:normal;text-decoration:none;vertical-align:baseline;} 		.xdDTTextRTL{height:100%;width:100%;margin-left:22px;overflow:hidden;padding:0px;white-space:nowrap;} 		.xdDTButtonRTL{margin-right:-21px;height:18px;width:20px;behavior: url(#default#DTPicker);} 		.xdMultiSelectFillinRTL{display:inline-block;white-space:nowrap;text-overflow:ellipsis;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;overflow:hidden;text-align:right;}.xdTextBox{display:inline-block;white-space:nowrap;text-overflow:ellipsis;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;text-align:left;word-wrap:normal;} 		.xdRichTextBox{display:inline-block;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow-x:hidden;word-wrap:break-word;text-overflow:ellipsis;text-align:left;font-weight:normal;font-style:normal;text-decoration:none;vertical-align:baseline;} 		.xdDTPicker{;display:inline;margin:1px;margin-bottom: 2px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;text-indent:0} 		.xdDTText{height:100%;width:100%;margin-right:22px;overflow:hidden;padding:0px;white-space:nowrap;} 		.xdDTButton{margin-left:-21px;height:18px;width:20px;behavior: url(#default#DTPicker);} 		.xdRepeatingTable TD {VERTICAL-ALIGN: top;}</style>
				<style tableEditor="TableStyleRulesID">TABLE.xdLayout TD {
	BORDER-BOTTOM: medium none; BORDER-LEFT: medium none; BORDER-TOP: medium none; BORDER-RIGHT: medium none
}
TABLE.msoUcTable TD {
	BORDER-BOTTOM: 1pt solid; BORDER-LEFT: 1pt solid; BORDER-TOP: 1pt solid; BORDER-RIGHT: 1pt solid
}
TABLE {
	BEHAVIOR: url (#default#urn::tables/NDTable)
}
</style>
				<style languageStyle="languageStyle">BODY {
	FONT-FAMILY: Verdana; FONT-SIZE: 10pt
}
TABLE {
	FONT-FAMILY: Verdana; FONT-SIZE: 10pt
}
SELECT {
	FONT-FAMILY: Verdana; FONT-SIZE: 10pt
}
.optionalPlaceholder {
	FONT-STYLE: normal; PADDING-LEFT: 20px; FONT-FAMILY: Verdana; COLOR: #333333; FONT-SIZE: xx-small; FONT-WEIGHT: normal; TEXT-DECORATION: none; BEHAVIOR: url(#default#xOptional)
}
.langFont {
	FONT-FAMILY: Verdana
}
.defaultInDocUI {
	FONT-FAMILY: Verdana; FONT-SIZE: xx-small
}
.optionalPlaceholder {
	PADDING-RIGHT: 20px
}
</style>
				<style themeStyle="urn:office.microsoft.com:themeBlue">BODY {
	BACKGROUND-COLOR: white; COLOR: black
}
TABLE {
	BORDER-BOTTOM: medium none; BORDER-LEFT: medium none; BORDER-COLLAPSE: collapse; BORDER-TOP: medium none; BORDER-RIGHT: medium none
}
TD {
	BORDER-BOTTOM-COLOR: #517dbf; BORDER-TOP-COLOR: #517dbf; BORDER-RIGHT-COLOR: #517dbf; BORDER-LEFT-COLOR: #517dbf
}
TH {
	BORDER-BOTTOM-COLOR: #517dbf; BACKGROUND-COLOR: #cbd8eb; BORDER-TOP-COLOR: #517dbf; COLOR: black; BORDER-RIGHT-COLOR: #517dbf; BORDER-LEFT-COLOR: #517dbf
}
.xdTableHeader {
	BACKGROUND-COLOR: #ebf0f9; COLOR: black
}
P {
	MARGIN-TOP: 0px
}
H1 {
	MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #1e3c7b
}
H2 {
	MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #1e3c7b
}
H3 {
	MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #1e3c7b
}
H4 {
	MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #1e3c7b
}
H5 {
	MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #517dbf
}
H6 {
	MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #ebf0f9
}
.primaryVeryDark {
	BACKGROUND-COLOR: #1e3c7b; COLOR: #ebf0f9
}
.primaryDark {
	BACKGROUND-COLOR: #517dbf; COLOR: white
}
.primaryMedium {
	BACKGROUND-COLOR: #cbd8eb; COLOR: black
}
.primaryLight {
	BACKGROUND-COLOR: #ebf0f9; COLOR: black
}
.accentDark {
	BACKGROUND-COLOR: #517dbf; COLOR: white
}
.accentLight {
	BACKGROUND-COLOR: #ebf0f9; COLOR: black
}
</style>
			</head>
			<body style="BACKGROUND-COLOR: #ffffff; COLOR: #000000">
				<div>
					<table style="BORDER-BOTTOM: medium none; BORDER-LEFT: medium none; WIDTH: 651px; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word; TABLE-LAYOUT: fixed; BORDER-TOP: medium none; BORDER-RIGHT: medium none" class="xdLayout" border="1" borderColor="buttontext">
						<colgroup>
							<col style="WIDTH: 224px"></col>
							<col style="WIDTH: 210px"></col>
							<col style="WIDTH: 217px"></col>
						</colgroup>
						<tbody vAlign="top">
							<tr style="MIN-HEIGHT: 20px">
								<td>
									<div>
										<font size="2" face="Verdana"><input style="BORDER-BOTTOM: #808080 6pt; BORDER-LEFT: #808080 6pt; BACKGROUND-COLOR: #d2def2; WIDTH: 227px; HEIGHT: 31px; BORDER-TOP: #808080 6pt; BORDER-RIGHT: #808080 6pt" class="langFont" title="" value="Datos Generales" size="15" type="button" xd:xctname="Button" xd:CtrlId="btTab1" tabIndex="0"/>
										</font>
									</div>
								</td>
								<td>
									<div>
										<font size="2" face="Verdana"><input style="BORDER-BOTTOM: #808080 6pt; BORDER-LEFT: #808080 6pt; BACKGROUND-COLOR: #ebf0f9; WIDTH: 204px; HEIGHT: 32px; BORDER-TOP: #808080 6pt; BORDER-RIGHT: #808080 6pt" class="langFont" title="" value="Estructura" size="29" type="button" xd:xctname="Button" xd:CtrlId="btTab2" tabIndex="0"/>
										</font>
									</div>
								</td>
								<td>
									<div>
										<font size="2" face="Verdana"><input style="BORDER-BOTTOM: #808080 6pt; BORDER-LEFT: #808080 6pt; BACKGROUND-COLOR: #ebf0f9; WIDTH: 214px; HEIGHT: 31px; BORDER-TOP: #808080 6pt; BORDER-RIGHT: #808080 6pt" class="langFont" title="" value="Reglas" size="40" type="button" xd:xctname="Button" xd:CtrlId="btTab3" tabIndex="0"/>
										</font>
									</div>
								</td>
							</tr>
							<tr style="MIN-HEIGHT: 756px">
								<td colSpan="3" style="BACKGROUND-COLOR: #cbd8eb">
									<h4 style="FONT-WEIGHT: normal">
										<strong/> </h4>
									<h4 style="FONT-WEIGHT: normal">
										<strong>Información general</strong>
									</h4>
									<div><xsl:apply-templates select="my:InformacionGeneral" mode="_2"/>
									</div>
									<h4 style="FONT-WEIGHT: normal">
										<strong>Información de agrupación</strong>
									</h4>
									<div style="FONT-WEIGHT: normal"><xsl:apply-templates select="my:informacionAgrupacion" mode="_5"/>
									</div>
									<div><xsl:apply-templates select="my:observaciones" mode="_6"/>
									</div><input class="langFont" title="" value="Cancelar" type="button" xd:xctname="Button" xd:CtrlId="cancelarTotal" tabIndex="0"/><input class="langFont" title="" value="Confirmar" type="button" xd:xctname="Button" xd:CtrlId="confirmarTotal" tabIndex="0"/>
								</td>
							</tr>
						</tbody>
					</table>
				</div>
			</body>
		</html>
	</xsl:template>
	<xsl:template match="my:InformacionGeneral" mode="_2">
		<div style="WIDTH: 561px; MARGIN-BOTTOM: 6px; HEIGHT: 210px" class="xdSection xdRepeating" title="" align="left" xd:xctname="Section" xd:CtrlId="CTRL5" tabIndex="-1">
			<div>
				<table style="BORDER-BOTTOM: medium none; BORDER-LEFT: medium none; WIDTH: 508px; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word; TABLE-LAYOUT: fixed; BORDER-TOP: medium none; BORDER-RIGHT: medium none" class="xdLayout" border="1" borderColor="buttontext">
					<colgroup>
						<col style="WIDTH: 164px"></col>
						<col style="WIDTH: 344px"></col>
					</colgroup>
					<tbody vAlign="top">
						<tr>
							<td>
								<div>
									<font size="2" face="Verdana">Identificador</font>
								</div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"><span hideFocus="1" class="xdTextBox xdBehavior_Formatting" title="" tabIndex="-1" xd:xctname="PlainText" xd:CtrlId="CTRL7" xd:datafmt="&quot;number&quot;,&quot;numDigits:0;negativeOrder:1;&quot;" xd:boundProp="xd:num" xd:disableEditing="yes" xd:binding="my:identificador" style="WIDTH: 219px; WHITE-SPACE: nowrap; HEIGHT: 23px">
											<xsl:attribute name="xd:num">
												<xsl:value-of select="my:identificador"/>
											</xsl:attribute>
											<xsl:choose>
												<xsl:when test="function-available('xdFormatting:formatString')">
													<xsl:value-of select="xdFormatting:formatString(my:identificador,&quot;number&quot;,&quot;numDigits:0;negativeOrder:1;&quot;)"/>
												</xsl:when>
												<xsl:otherwise>
													<xsl:value-of select="my:identificador"/>
												</xsl:otherwise>
											</xsl:choose>
										</span>
									</font>
								</div>
							</td>
						</tr>
						<tr>
							<td>
								<div>
									<font size="2" face="Verdana">Autor</font>
								</div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"><span hideFocus="1" class="xdTextBox" title="" tabIndex="-1" xd:xctname="PlainText" xd:CtrlId="CTRL8" xd:disableEditing="yes" xd:binding="my:autor" style="WIDTH: 218px; WHITE-SPACE: nowrap; HEIGHT: 21px">
											<xsl:value-of select="my:autor"/>
										</span>
									</font>
								</div>
							</td>
						</tr>
						<tr>
							<td>
								<div>
									<font size="2" face="Verdana">Versión</font>
								</div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"><span hideFocus="1" class="xdTextBox xdBehavior_Formatting" title="" tabIndex="-1" xd:xctname="PlainText" xd:CtrlId="CTRL9" xd:datafmt="&quot;number&quot;,&quot;numDigits:0;negativeOrder:1;&quot;" xd:boundProp="xd:num" xd:disableEditing="yes" xd:binding="my:version" style="WIDTH: 219px; WHITE-SPACE: nowrap; HEIGHT: 24px">
											<xsl:attribute name="xd:num">
												<xsl:value-of select="my:version"/>
											</xsl:attribute>
											<xsl:choose>
												<xsl:when test="function-available('xdFormatting:formatString')">
													<xsl:value-of select="xdFormatting:formatString(my:version,&quot;number&quot;,&quot;numDigits:0;negativeOrder:1;&quot;)"/>
												</xsl:when>
												<xsl:otherwise>
													<xsl:value-of select="my:version"/>
												</xsl:otherwise>
											</xsl:choose>
										</span>
									</font>
								</div>
							</td>
						</tr>
						<tr>
							<td>
								<div>
									<font size="2" face="Verdana">Fecha de creación</font>
								</div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"><span hideFocus="1" class="xdTextBox" title="" tabIndex="-1" xd:xctname="PlainText" xd:CtrlId="CTRL10" xd:disableEditing="yes" xd:binding="my:fechaCreacion" style="WIDTH: 220px; WHITE-SPACE: nowrap; HEIGHT: 21px">
											<xsl:value-of select="my:fechaCreacion"/>
										</span>
									</font>
								</div>
							</td>
						</tr>
						<tr>
							<td>
								<div>
									<font size="2" face="Verdana">*Fecha vigencia desde</font>
								</div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana">
										<div style="WIDTH: 220px; HEIGHT: 22px" class="xdDTPicker" title="" noWrap="1" xd:xctname="DTPicker" xd:CtrlId="CTRL11"><span hideFocus="1" class="xdDTText xdBehavior_FormattingNoBUI" contentEditable="true" tabIndex="0" xd:xctname="DTPicker_DTText" xd:datafmt="&quot;date&quot;,&quot;dateFormat:Short Date;&quot;" xd:boundProp="xd:num" xd:binding="my:fechavigenciadesde" xd:innerCtrl="_DTText">
												<xsl:attribute name="xd:num">
													<xsl:value-of select="my:fechavigenciadesde"/>
												</xsl:attribute>
												<xsl:choose>
													<xsl:when test="function-available('xdFormatting:formatString')">
														<xsl:value-of select="xdFormatting:formatString(my:fechavigenciadesde,&quot;date&quot;,&quot;dateFormat:Short Date;&quot;)"/>
													</xsl:when>
													<xsl:otherwise>
														<xsl:value-of select="my:fechavigenciadesde"/>
													</xsl:otherwise>
												</xsl:choose>
											</span>
											<button class="xdDTButton" xd:xctname="DTPicker_DTButton" xd:innerCtrl="_DTButton" tabIndex="-1">
												<img src="res://infopath.exe/calendar.gif"/>
											</button>
										</div>
									</font>
								</div>
							</td>
						</tr>
						<tr>
							<td>
								<div>
									<font size="2" face="Verdana">*Fecha vigencia hasta</font>
								</div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana">
										<div style="WIDTH: 223px" class="xdDTPicker" title="" noWrap="1" xd:xctname="DTPicker" xd:CtrlId="CTRL12"><span hideFocus="1" class="xdDTText xdBehavior_FormattingNoBUI" contentEditable="true" tabIndex="0" xd:xctname="DTPicker_DTText" xd:datafmt="&quot;date&quot;,&quot;dateFormat:Short Date;&quot;" xd:boundProp="xd:num" xd:binding="my:fechavigenciahasta" xd:innerCtrl="_DTText">
												<xsl:if test="function-available('xdXDocument:GetDOM')">
													<xsl:attribute name="style">
														<xsl:choose>
															<xsl:when test="msxsl:string-compare(my:fechavigenciahasta, my:fechavigenciadesde) &lt;= 0">COLOR: #ff6600; FONT-WEIGHT: bold; TEXT-DECORATION: line-through</xsl:when>
															<xsl:when test="msxsl:string-compare(my:fechavigenciahasta, my:fechavigenciadesde) &gt; 0">COLOR: #000000</xsl:when>
														</xsl:choose>
													</xsl:attribute>
													<xsl:attribute name="xd:num">
														<xsl:value-of select="my:fechavigenciahasta"/>
													</xsl:attribute>
													<xsl:choose>
														<xsl:when test="function-available('xdFormatting:formatString')">
															<xsl:value-of select="xdFormatting:formatString(my:fechavigenciahasta,&quot;date&quot;,&quot;dateFormat:Short Date;&quot;)"/>
														</xsl:when>
														<xsl:otherwise>
															<xsl:value-of select="my:fechavigenciahasta"/>
														</xsl:otherwise>
													</xsl:choose>
												</xsl:if>
											</span>
											<button class="xdDTButton" xd:xctname="DTPicker_DTButton" xd:innerCtrl="_DTButton" tabIndex="-1">
												<img src="res://infopath.exe/calendar.gif"/>
											</button>
										</div>
									</font>
								</div>
							</td>
						</tr>
						<tr>
							<td>
								<div>
									<font size="2" face="Verdana">*Nombre</font>
								</div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"><span hideFocus="1" class="xdTextBox" title="" tabIndex="0" xd:xctname="PlainText" xd:CtrlId="CTRL13" xd:binding="my:nombre" style="WIDTH: 223px">
											<xsl:value-of select="my:nombre"/>
										</span>
									</font>
								</div>
							</td>
						</tr>
						<tr>
							<td>
								<div>
									<font size="2" face="Verdana">*Descripción</font>
								</div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"><span hideFocus="1" class="xdTextBox" title="" tabIndex="0" xd:xctname="PlainText" xd:CtrlId="CTRL14" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" xd:binding="my:descripcion" style="OVERFLOW-X: auto; OVERFLOW-Y: auto; WIDTH: 271px; WORD-WRAP: break-word; WHITE-SPACE: normal; HEIGHT: 50px">
											<xsl:choose>
												<xsl:when test="function-available('xdFormatting:formatString')">
													<xsl:value-of select="xdFormatting:formatString(my:descripcion,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
												</xsl:when>
												<xsl:otherwise>
													<xsl:value-of select="my:descripcion" disable-output-escaping="yes"/>
												</xsl:otherwise>
											</xsl:choose>
										</span>
									</font>
								</div>
							</td>
						</tr>
						<tr>
							<td>
								<div>
									<font size="2" face="Verdana">*Es modificable</font>
								</div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"><input class="xdBehavior_Boolean" title="" type="checkbox" tabIndex="0" xd:xctname="CheckBox" xd:CtrlId="CTRL15" xd:boundProp="xd:value" xd:binding="my:esModificable" xd:onValue="true" xd:offValue="false">
											<xsl:attribute name="xd:value">
												<xsl:value-of select="my:esModificable"/>
											</xsl:attribute>
											<xsl:if test="my:esModificable=&quot;true&quot;">
												<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
											</xsl:if>
										</input>
									</font>
								</div>
							</td>
						</tr>
					</tbody>
				</table>
			</div>
			<div> </div>
			<div> </div>
		</div>
	</xsl:template>
	<xsl:template match="my:informacionAgrupacion" mode="_5">
		<div style="WIDTH: 601px; MARGIN-BOTTOM: 6px; HEIGHT: 179px" class="xdSection xdRepeating" title="" align="left" xd:xctname="Section" xd:CtrlId="CTRL17" tabIndex="-1">
			<div> </div>
			<div>
				<table style="BORDER-BOTTOM: medium none; BORDER-LEFT: medium none; WIDTH: 592px; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word; TABLE-LAYOUT: fixed; BORDER-TOP: medium none; BORDER-RIGHT: medium none" class="xdLayout" border="1" borderColor="buttontext">
					<colgroup>
						<col style="WIDTH: 138px"></col>
						<col style="WIDTH: 138px"></col>
						<col style="WIDTH: 138px"></col>
						<col style="WIDTH: 178px"></col>
					</colgroup>
					<tbody vAlign="top">
						<tr>
							<td>
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"><input class="langFont" title="" value="Agregar" type="button" xd:xctname="Button" xd:CtrlId="CTRL18_5" tabIndex="0"/>
									</font>
								</div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
						</tr>
						<tr>
							<td>
								<div>
									<font size="2" face="Verdana">*Área responsable del atributo:</font>
								</div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
						</tr>
						<tr>
							<td>
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
						</tr>
						<tr>
							<td>
								<div>
									<font size="2" face="Verdana">Pilar</font>
								</div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
						</tr>
						<tr>
							<td>
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
						</tr>
						<tr>
							<td>
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"><input class="langFont" title="" value="Cancelar" type="button" xd:xctname="Button" xd:CtrlId="Cancelar" tabIndex="0"/>
									</font>
								</div>
							</td>
							<td>
								<div>
									<font size="2" face="Verdana"><input class="langFont" title="" value="Anterior" type="button" xd:xctname="Button" xd:CtrlId="Anterior" tabIndex="0"/><input class="langFont" title="" value="Siguiente" type="button" xd:xctname="Button" xd:CtrlId="siguiente" tabIndex="0"/>
									</font>
								</div>
							</td>
						</tr>
					</tbody>
				</table>
			</div>
			<div> </div>
		</div>
	</xsl:template>
	<xsl:template match="my:observaciones" mode="_6">
		<div style="BORDER-BOTTOM: #000000 1pt solid; BORDER-LEFT: #000000 1pt solid; WIDTH: 100%; MARGIN-BOTTOM: 6px; BORDER-TOP: #000000 1pt solid; BORDER-RIGHT: #000000 1pt solid" class="xdSection xdRepeating" title="" align="left" xd:xctname="Section" xd:CtrlId="CTRL22" tabIndex="-1">
			<h4 style="FONT-WEIGHT: normal">
				<strong>Observaciones</strong>
			</h4>
			<div style="FONT-WEIGHT: normal"> </div>
			<div>
				<table style="BORDER-BOTTOM: medium none; BORDER-LEFT: medium none; WIDTH: 635px; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word; TABLE-LAYOUT: fixed; BORDER-TOP: medium none; BORDER-RIGHT: medium none" class="xdLayout" border="1" borderColor="buttontext">
					<colgroup>
						<col style="WIDTH: 127px"></col>
						<col style="WIDTH: 127px"></col>
						<col style="WIDTH: 127px"></col>
						<col style="WIDTH: 127px"></col>
						<col style="WIDTH: 127px"></col>
					</colgroup>
					<tbody vAlign="top">
						<tr>
							<td style="BORDER-BOTTOM: #000000 1pt solid; BORDER-LEFT: #000000 1pt solid; BORDER-TOP: #000000 1pt solid; BORDER-RIGHT: #000000 1pt solid">
								<div>
									<font size="2" face="Verdana">Tarea</font>
								</div>
							</td>
							<td style="BORDER-BOTTOM: #000000 1pt solid; BORDER-LEFT: #000000 1pt solid; BORDER-TOP: #000000 1pt solid; BORDER-RIGHT: #000000 1pt solid">
								<div>
									<font size="2" face="Verdana">Observación</font>
								</div>
							</td>
							<td style="BORDER-BOTTOM: #000000 1pt solid; BORDER-LEFT: #000000 1pt solid; BORDER-TOP: #000000 1pt solid; BORDER-RIGHT: #000000 1pt solid">
								<div>
									<font size="2" face="Verdana">Autor</font>
								</div>
							</td>
							<td style="BORDER-BOTTOM: #000000 1pt solid; BORDER-LEFT: #000000 1pt solid; BORDER-TOP: #000000 1pt solid; BORDER-RIGHT: #000000 1pt solid">
								<div>
									<font size="2" face="Verdana">Fecha</font>
								</div>
							</td>
							<td style="BORDER-BOTTOM: #000000 1pt solid; BORDER-LEFT: #000000 1pt solid; BORDER-TOP: #000000 1pt solid; BORDER-RIGHT: #000000 1pt solid">
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
						</tr>
						<tr>
							<td style="BORDER-BOTTOM: #000000 1pt solid; BORDER-LEFT: #000000 1pt solid; BORDER-TOP: #000000 1pt solid; BORDER-RIGHT: #000000 1pt solid">
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
							<td style="BORDER-BOTTOM: #000000 1pt solid; BORDER-LEFT: #000000 1pt solid; BORDER-TOP: #000000 1pt solid; BORDER-RIGHT: #000000 1pt solid">
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
							<td style="BORDER-BOTTOM: #000000 1pt solid; BORDER-LEFT: #000000 1pt solid; BORDER-TOP: #000000 1pt solid; BORDER-RIGHT: #000000 1pt solid">
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
							<td style="BORDER-BOTTOM: #000000 1pt solid; BORDER-LEFT: #000000 1pt solid; BORDER-TOP: #000000 1pt solid; BORDER-RIGHT: #000000 1pt solid">
								<div>
									<font size="2" face="Verdana"></font> </div>
							</td>
							<td style="BORDER-BOTTOM: #000000 1pt solid; BORDER-LEFT: #000000 1pt solid; BORDER-TOP: #000000 1pt solid; BORDER-RIGHT: #000000 1pt solid">
								<div>
									<font size="2" face="Verdana">Eliminar</font>
								</div>
							</td>
						</tr>
					</tbody>
				</table>
			</div>
			<div> </div>
			<div><input class="langFont" title="" value="Agregar" type="button" xd:xctname="Button" xd:CtrlId="agregarObservacion" tabIndex="0"/>
			</div>
			<div> </div>
		</div>
	</xsl:template>
</xsl:stylesheet>
