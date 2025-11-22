using System;
public class Address
{
    private string streetAddress;
    private string city;
    private string stateProvince;
    private string country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    public string GetStreetAddress() { return streetAddress; }
    public string GetCity() { return city; }
    public string GetStateProvince() { return stateProvince; }
    public string GetCountry() { return country; }

    public void SetStreetAddress(string streetAddress) { this.streetAddress = streetAddress; }
    public void SetCity(string city) { this.city = city; }
    public void SetStateProvince(string stateProvince) { this.stateProvince = stateProvince; }
    public void SetCountry(string country) { this.country = country; }

    public bool IsInUSA()
    {
        return country.ToUpper() == "USA" || country.ToUpper() == "UNITED STATES";
    }

    public string GetFullAddress()
    {
        return $"{streetAddress}\n{city}, {stateProvince}\n{country}";
    }
}
