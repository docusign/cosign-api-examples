
package oasis.names.tc.spml._2._0.search;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlType;
import oasis.names.tc.spml._2._0.PSOType;
import oasis.names.tc.spml._2._0.ResponseType;


/**
 * <p>Java class for SearchResponseType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SearchResponseType">
 *   &lt;complexContent>
 *     &lt;extension base="{urn:oasis:names:tc:SPML:2:0}ResponseType">
 *       &lt;sequence>
 *         &lt;element name="pso" type="{urn:oasis:names:tc:SPML:2:0}PSOType" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;element name="iterator" type="{urn:oasis:names:tc:SPML:2:0:search}ResultsIteratorType" minOccurs="0"/>
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
@XmlType(name = "SearchResponseType", propOrder = {
    "pso",
    "iterator"
})
public class SearchResponseType
    extends ResponseType
{

    protected List<PSOType> pso;
    protected ResultsIteratorType iterator;

    /**
     * Gets the value of the pso property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the pso property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getPso().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link PSOType }
     * 
     * 
     */
    public List<PSOType> getPso() {
        if (pso == null) {
            pso = new ArrayList<PSOType>();
        }
        return this.pso;
    }

    /**
     * Gets the value of the iterator property.
     * 
     * @return
     *     possible object is
     *     {@link ResultsIteratorType }
     *     
     */
    public ResultsIteratorType getIterator() {
        return iterator;
    }

    /**
     * Sets the value of the iterator property.
     * 
     * @param value
     *     allowed object is
     *     {@link ResultsIteratorType }
     *     
     */
    public void setIterator(ResultsIteratorType value) {
        this.iterator = value;
    }

}
