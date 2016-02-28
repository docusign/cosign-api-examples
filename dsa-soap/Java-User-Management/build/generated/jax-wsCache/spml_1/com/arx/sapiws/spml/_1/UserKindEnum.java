
package com.arx.sapiws.spml._1;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlEnumValue;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for UserKindEnum.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="UserKindEnum">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="None"/>
 *     &lt;enumeration value="User"/>
 *     &lt;enumeration value="Group"/>
 *     &lt;enumeration value="Computer"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlType(name = "UserKindEnum", namespace = "http://arx.com/SAPIWS/SPML/1.0")
@XmlEnum
public enum UserKindEnum {

    @XmlEnumValue("None")
    NONE("None"),
    @XmlEnumValue("User")
    USER("User"),
    @XmlEnumValue("Group")
    GROUP("Group"),
    @XmlEnumValue("Computer")
    COMPUTER("Computer");
    private final String value;

    UserKindEnum(String v) {
        value = v;
    }

    public String value() {
        return value;
    }

    public static UserKindEnum fromValue(String v) {
        for (UserKindEnum c: UserKindEnum.values()) {
            if (c.value.equals(v)) {
                return c;
            }
        }
        throw new IllegalArgumentException(v);
    }

}
