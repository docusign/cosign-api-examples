
package oasis.names.tc.spml._2._0;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for ModifyResponseType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="ModifyResponseType">
 *   &lt;complexContent>
 *     &lt;extension base="{urn:oasis:names:tc:SPML:2:0}ResponseType">
 *       &lt;sequence>
 *         &lt;element name="pso" type="{urn:oasis:names:tc:SPML:2:0}PSOType" minOccurs="0"/>
 *       &lt;/sequence>
 *       &lt;anyAttribute/>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ModifyResponseType", propOrder = {
    "pso"
})
public class ModifyResponseType
    extends ResponseType
{

    protected PSOType pso;

    /**
     * Gets the value of the pso property.
     * 
     * @return
     *     possible object is
     *     {@link PSOType }
     *     
     */
    public PSOType getPso() {
        return pso;
    }

    /**
     * Sets the value of the pso property.
     * 
     * @param value
     *     allowed object is
     *     {@link PSOType }
     *     
     */
    public void setPso(PSOType value) {
        this.pso = value;
    }

}
