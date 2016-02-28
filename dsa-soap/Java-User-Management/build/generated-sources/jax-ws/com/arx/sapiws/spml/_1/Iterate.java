
package com.arx.sapiws.spml._1;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import oasis.names.tc.spml._2._0.search.IterateRequestType;


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
 *         &lt;element ref="{urn:oasis:names:tc:SPML:2:0:search}iterateRequest" minOccurs="0"/>
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
    "iterateRequest"
})
@XmlRootElement(name = "iterate")
public class Iterate {

    @XmlElement(namespace = "urn:oasis:names:tc:SPML:2:0:search")
    protected IterateRequestType iterateRequest;

    /**
     * Gets the value of the iterateRequest property.
     * 
     * @return
     *     possible object is
     *     {@link IterateRequestType }
     *     
     */
    public IterateRequestType getIterateRequest() {
        return iterateRequest;
    }

    /**
     * Sets the value of the iterateRequest property.
     * 
     * @param value
     *     allowed object is
     *     {@link IterateRequestType }
     *     
     */
    public void setIterateRequest(IterateRequestType value) {
        this.iterateRequest = value;
    }

}
