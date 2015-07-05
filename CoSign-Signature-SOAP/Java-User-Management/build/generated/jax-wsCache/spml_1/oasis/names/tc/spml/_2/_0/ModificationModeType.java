
package oasis.names.tc.spml._2._0;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlEnumValue;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for ModificationModeType.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="ModificationModeType">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="add"/>
 *     &lt;enumeration value="replace"/>
 *     &lt;enumeration value="delete"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlType(name = "ModificationModeType")
@XmlEnum
public enum ModificationModeType {

    @XmlEnumValue("add")
    ADD("add"),
    @XmlEnumValue("replace")
    REPLACE("replace"),
    @XmlEnumValue("delete")
    DELETE("delete");
    private final String value;

    ModificationModeType(String v) {
        value = v;
    }

    public String value() {
        return value;
    }

    public static ModificationModeType fromValue(String v) {
        for (ModificationModeType c: ModificationModeType.values()) {
            if (c.value.equals(v)) {
                return c;
            }
        }
        throw new IllegalArgumentException(v);
    }

}
