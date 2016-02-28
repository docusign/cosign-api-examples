
package oasis.names.tc.spml._2._0;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlEnumValue;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for ExecutionModeType.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="ExecutionModeType">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="synchronous"/>
 *     &lt;enumeration value="asynchronous"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlType(name = "ExecutionModeType")
@XmlEnum
public enum ExecutionModeType {

    @XmlEnumValue("synchronous")
    SYNCHRONOUS("synchronous"),
    @XmlEnumValue("asynchronous")
    ASYNCHRONOUS("asynchronous");
    private final String value;

    ExecutionModeType(String v) {
        value = v;
    }

    public String value() {
        return value;
    }

    public static ExecutionModeType fromValue(String v) {
        for (ExecutionModeType c: ExecutionModeType.values()) {
            if (c.value.equals(v)) {
                return c;
            }
        }
        throw new IllegalArgumentException(v);
    }

}
