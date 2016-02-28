
package oasis.names.tc.spml._2._0.search;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlEnumValue;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for ScopeType.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="ScopeType">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="pso"/>
 *     &lt;enumeration value="oneLevel"/>
 *     &lt;enumeration value="subTree"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlType(name = "ScopeType")
@XmlEnum
public enum ScopeType {

    @XmlEnumValue("pso")
    PSO("pso"),
    @XmlEnumValue("oneLevel")
    ONE_LEVEL("oneLevel"),
    @XmlEnumValue("subTree")
    SUB_TREE("subTree");
    private final String value;

    ScopeType(String v) {
        value = v;
    }

    public String value() {
        return value;
    }

    public static ScopeType fromValue(String v) {
        for (ScopeType c: ScopeType.values()) {
            if (c.value.equals(v)) {
                return c;
            }
        }
        throw new IllegalArgumentException(v);
    }

}
