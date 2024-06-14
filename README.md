##[Cn]

在Monster Hunter Frontier （任意版本） 中，浏览角色信息，有一个ID，形如"W6BX11"，这种六位数。

通过查看服务端代码和截取包，发现服务器仅发送了uint32的数据库的CharacterID，并没有发送"W6BX11"这种字符串。

这完全是客户端逻辑，为了不显示真实ID，做了一个换算。

我搞清楚了其换算机制，机制如下：

1. MHF客户端是基于0~Z的36进制，但是把‘0’、‘I’、‘O’、‘S’ 这四个字符扔了，变成32进制。

2. 从0到32的数值，对应的表示符号是“123456789ABCDEFGHJKLMNPQRTUVWXYZ”

3. 按照如上对应表，把uint32的CharacterID进行转换之后。

4. 将结果倒序,(并不是HEX的高位在前，是直接整个字符串倒序）

5. 然后不足6位填充“1”，因为“1”就是0

相反的行为，换算回去

已用于皓月云MHF-FW5在线网页游戏实况的需要内存采集的一部分功能。

##[En] 

In Monster Hunter Frontier (any version), when browsing character information, there is an ID in the form of "W6BX11", a six-digit number.

By checking the server code and intercepting the package, it was found that the server only sent the CharacterID of the uint32 database, and did not send the string "W6BX11".

This is completely client logic. In order not to display the real ID, a conversion was made.

I figured out its conversion mechanism, which is as follows:

1. The MHF client is based on 36-decimal system 0~Z, but the four characters '0', 'I', 'O', and 'S' are thrown away and converted to 32-decimal system.

2. The corresponding symbols for the values ​​from 0 to 32 are "123456789ABCDEFGHJKLMNPQRTUVWXYZ"

3. According to the corresponding table above, convert the CharacterID of uint32.

4. Reverse the result (not the high bit of HEX first, but the whole string in reverse order)

5. Then fill "1" if there are less than 6 bits, because "1" is 0

The opposite behavior, convert back

It has been used for some functions of axibug.com MHF-FW5 online web game live that require memory acquisition.