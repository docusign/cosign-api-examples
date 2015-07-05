
package com.arx.sapiws.spml._1;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import oasis.names.tc.spml._2._0.ModifyResponseType;


/**
 * <p>Java class for anonymous complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType>
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{urn:oasis:names:tc:SPML:2:0}modifyResponse" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "modifyResponse"
})
@XmlRootElement(name = "modifyResponse")
public class ModifyResponse {

    @XmlElement(namespace = "urn:oasis:names:tc:SPML:2:0")
    protected ModifyResponseType modifyResponse;

    /**
     * Gets the value of the modifyResponse property.
     * 
     * @return
     *     possible object is
     *     {@link ModifyResponseType }
     *     
     */
    public ModifyResponseType getModifyResponse() {
        return modifyResponse;
    }

    /**
     * Sets the value of the modifyResponse property.
     * 
     * @param value
     *     allowed object is
     *     {@link ModifyResponseType }
     *     
     */
    public void setModifyResponse(ModifyResponseType value) {
        this.modifyResponse = value;
    }

}
