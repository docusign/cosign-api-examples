
package com.arx.sapiws.spml._1;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import oasis.names.tc.spml._2._0.AddResponseType;


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
 *         &lt;element ref="{urn:oasis:names:tc:SPML:2:0}addResponse" minOccurs="0"/>
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
    "addResponse"
})
@XmlRootElement(name = "addResponse")
public class AddResponse {

    @XmlElement(namespace = "urn:oasis:names:tc:SPML:2:0")
    protected AddResponseType addResponse;

    /**
     * Gets the value of the addResponse property.
     * 
     * @return
     *     possible object is
     *     {@link AddResponseType }
     *     
     */
    public AddResponseType getAddResponse() {
        return addResponse;
    }

    /**
     * Sets the value of the addResponse property.
     * 
     * @param value
     *     allowed object is
     *     {@link AddResponseType }
     *     
     */
    public void setAddResponse(AddResponseType value) {
        this.addResponse = value;
    }

}
