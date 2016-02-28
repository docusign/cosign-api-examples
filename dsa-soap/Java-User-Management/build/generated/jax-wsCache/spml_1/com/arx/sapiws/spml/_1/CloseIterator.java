
package com.arx.sapiws.spml._1;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import oasis.names.tc.spml._2._0.search.CloseIteratorRequestType;


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
 *         &lt;element ref="{urn:oasis:names:tc:SPML:2:0:search}closeIteratorRequest" minOccurs="0"/>
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
    "closeIteratorRequest"
})
@XmlRootElement(name = "closeIterator")
public class CloseIterator {

    @XmlElement(namespace = "urn:oasis:names:tc:SPML:2:0:search")
    protected CloseIteratorRequestType closeIteratorRequest;

    /**
     * Gets the value of the closeIteratorRequest property.
     * 
     * @return
     *     possible object is
     *     {@link CloseIteratorRequestType }
     *     
     */
    public CloseIteratorRequestType getCloseIteratorRequest() {
        return closeIteratorRequest;
    }

    /**
     * Sets the value of the closeIteratorRequest property.
     * 
     * @param value
     *     allowed object is
     *     {@link CloseIteratorRequestType }
     *     
     */
    public void setCloseIteratorRequest(CloseIteratorRequestType value) {
        this.closeIteratorRequest = value;
    }

}
