
package com.arx.sapiws.spml._1;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import oasis.names.tc.spml._2._0.AddRequestType;


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
 *         &lt;element ref="{urn:oasis:names:tc:SPML:2:0}addRequest" minOccurs="0"/>
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
    "addRequest"
})
@XmlRootElement(name = "addGroup")
public class AddGroup {

    @XmlElement(namespace = "urn:oasis:names:tc:SPML:2:0")
    protected AddRequestType addRequest;

    /**
     * Gets the value of the addRequest property.
     * 
     * @return
     *     possible object is
     *     {@link AddRequestType }
     *     
     */
    public AddRequestType getAddRequest() {
        return addRequest;
    }

    /**
     * Sets the value of the addRequest property.
     * 
     * @param value
     *     allowed object is
     *     {@link AddRequestType }
     *     
     */
    public void setAddRequest(AddRequestType value) {
        this.addRequest = value;
    }

}
