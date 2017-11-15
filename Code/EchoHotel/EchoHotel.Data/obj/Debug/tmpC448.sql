ALTER TABLE [dbo].[Acomodacao] ADD [UrlImg] [nvarchar](100)
ALTER TABLE [dbo].[Hotel] ADD [UrlImg] [nvarchar](100)
ALTER TABLE [dbo].[Cliente] ADD [Senha] [nvarchar](100) NOT NULL DEFAULT ''
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201711032217372_AlteracaoNoModelo', N'EchoHotel.Data.Migrations.Configuration',  0x1F8B0800000000000400ED5DCD6EE4B811BE07C83B083A06B36EDB830536467B179EF6387176C69EB8ED416E035AA2DB44F4D391D8868D204F96C33ED2BE42A87FFE8B5453EAF6C498CB342916C96255B158647DFEFDBFBFCD7F798E23EF0966394A9353FFE8E0D0F76012A4214A56A7FE063FFCF093FFCBCF7FFCC3FC63183F7B5F9BEFDE17DF9196497EEA3F62BC3E99CDF2E011C6203F885190A579FA800F82349E81309D1D1F1EFE797674348384844F6879DEFC66936014C3F207F9B9489300AEF106449FD31046795D4E6A962555EF0AC4305F83009EFA1F83C7F4AF2986D1C139C0E08034C5F019FBDE59840019CD12460FBE079224C50093B19EDCE57089B334592DD7A40044B72F6B48BE7B00510EEB399C749F9B4EE7F0B898CEAC6BD8900A36394E634B8247EF6BFECCF8E683B8ECB7FC231CFC48388D5F8A59975C3CF5CF488B340401487D8FEFEE641165C5A70C9BC907283928E920981F74EDDF79FC57EF5A11219254FC7BE72D3611DE64F034811B9C81E89DF765731FA1E057F8729BFE1326A7C9268AE8019321933AA680147DC9D235CCF0CB0D7CA8A77119FADE8C6D37E31BB6CDA836D5F42E13FCFED8F7AE48E7E03E82AD3C50AC58E234837F8109CC0086E1178031CC9282062C392AF4CEF555B2A5BF433D91AF204AB386C4390C500C22DFFB9291FFD50AFB93EF2D035010B4A77E8EF2759AA02718355D7C48D30882C49AD20210E5442108E176F3BDCBA2CB78D5D0207A4BCC90EF7D06CF9F60B2C28F64BE87C4F05CA06718362535DDBB0411AB451AE16CD33F719807192A3540D9D38FC37ABA024F68550A10D7E7598802520A50EE7B37302A3FC91FD1BA3259074D75F4ADD1AF14922F2FB234BE4923AA3DF3C1B75B90AD20B17EB7A9EEAB65BAC9028BB196B22B1D6659A31AA250290C4FFC4236B4F9AC335A7A53D6CC76A0256B9ABF19324D5F57690C1D68E45E59BE5BB44E2D2D955AB1696570A7D98D62E835BB51301BCD5658A05A3729332568765BA752ECEE83ADF4BAB63F4374BA2C7DD3E7F1F5B9C721B8FAF2B7D13BF93B0E1995DAC6F320B43EE638236AB125A1117D8BDD384B1F931012B39B5AFBB2832DA6A593C15B4AB51BE2C857B3B2948AD189A6D47470CD7A6886D67DC20FACA9510CABAD960DCAD87C77DD0FB1E04DEB3723AEB3AF703DBD4F76B301A35B9B0F006599CE768E34B7AB4D0C33DE27EC5903E6C03BDD50C93E05C21DB0E8EE42D3E7B1F5DA1B9B9345848852C061D6A46EFC664CF6EE84B74CEF3398ECA4EB22727C057272A8240C6A358994C25B140F50C8A11E126F50D60F3A5E1C8D624C882E443B587C983CBAD84C2CBB3DC3E8A95D6FE360A7D2155BA4F13A037227B1AAFBD61AAFCE13636B84A334576D1BBBD3BA870D519983C8D7092EA2F0C1564E6235CD8146BD6CFB66D375B6240DD12A6D983CB59EDD9259446CE7CE6378B538BA3B96B6AABA8D360B4A2357F6412A730373983D0DD499BAF19BD26895A658AC6DB7F1EE8274BFAFFF2A13F1290D803E5AE5E8CE8DF85C974911F5D8DADF2A48DDC22C46C9F6B40A8F00B8F308E8CB758919A995F01BFD59674AC45AC19C483EB18D1F35665933BCE6137168B539530DABAEB6B17267799E06A81C097FABC78400D9D9111FC433BA3DA9849AB98721C24DEC1B5A138B46C673EAFF49E05D1FF5D665A3A8532BAA253F9F5133D633428C83AA86A9098A7643AC6F55D8D11DF9BCD9BE4ECE610431F4CE82EA01CB829C94CA40076FBA49FFE603DA8667C58B21F8409CCEA478C1B320324BB625946071C7414980D620EA630BD7D070B32AE6DC76C1D79CC3354C8A7DA68F03267DB78F47C401B4FD708BD1C7207BB9EBE2DB3DAB2C0976F7489D4EE5D4778DF6BA6C3DE9F660A41F9D7846DA7AC2C2A98A22D91DD778E575A826FC0026D3119E99261DD321979DE808772050ADADEA74D0AD6DB3D79ACB8B2A7E40D16C8E2923DAFA4192261FFA0492265F07938EA963E66E048D0FD928C54219BFE9150CADB4A9A23ED3D927D510A6901B05535F858D929C3654ABAC3B7A74EBDC0620CCC547736031F204776FB3D4339840FED4EB62D2391B89D8A90CD6DB5C9F98F0E74B27B2C79D4A7B37DFFD913976E413CA1BBB0E46FB641B3B9B40CEAA504291FB415AC0AC31B84D64B34D0A1102A57739AC63A5791DB6E285A720BC845812CFE9E21712AB25082147A73BB08864BABA1E2AF5D142A05097F7B4EE7669814057D543A3752004126D4D1F855AE5440275454FFBD60E0804DA1A8E022543920561DF9951DF6A9FEFF2226E1A8F6A67C38884A031A601289A9C5A18672C070CB82379812772A6273C6518A0A2A6201563C3B0D2C89CA0DEFA2919A1889798454C86B0410C919888D76026744642C502F919C5247E3260FAC28184A2A1B467F673E76FFEC4B9EB420126C1006ADC721B6872FAA789282CF180B90BCF0524B3D79E4FCD4EA8FD83373B928E2301B24B1B910F7D872DD3E3163507C586667ABE1ACB24F2B7446A5EC89C7E13B77F200F383FBF57AF34736F6EAB5A17B3AD9BCFAA9CE4BA603E53242FCF3F83F51A252B2A99B92EF1965526F3E287A57D7A6F5CD19805CC2EC33BC46D4F38CDC00A72B5E5D52FBC40598E8BABD47B50DC702EC258F84C70A815AE59D39DE0338B6BD6F86C4D93E2FF9CF7CE24761FA8A9751CBD20932C9EF295F38572B9171A7B4576398840267970B048A34D9CA84F54EAD6EDCD0D4D42799DA3A6535FFDD354EA22731A747E2F4D882E37A746E7F8D2D4E872736A4DF20A4DA929B39861976CC34CB02B1669CD679CD408C755414A85333E2BF7665AD1FA632E944245CC4427D46DC75189EA7931DDBE2A995619AA944F9A4455B2370252F9BD0E84434AC8403014EDF65528AA1443C6129525E614F8FC419A165F6745B5CB24E4487615E3DAB871AD2E7DB14153D25D78EC4CAD34E7126BCD52D132502E75D371F4AB4C106394A328306F5FE67AD1EDCB02F3F64D1E174DA229B3B0127556166327EA320B5EC8BC166B8FA549BB6224BE2EB3D0C00B4EFB2EF64857D4210C6B55519032D01465CB7DDD88A844269A0C556C61ECB9CC24C6E27375631B6CA53A15694A8C2E150516A3A9528E98815445163CAFF287187E5745E634EA64209A465DB43F0AA90AA0D8EBA39492893A2A1A8EB46D31692B8C903135167E3F9D8AC2B8FF7485C508BBF740CCF0D4CF8476263D4DECCC81F8284819C88FB2E55802D45C43B3C2A3BA9C5653621F4F305642FBAC424DD1C531964BDA1035A4ADB2DB749AD40C7EC369CAEDA8B5D9193CB9B6C2CE4C03D14C4B95766C4563E3C58A000F7B6F6A1ECB61DB29C336FA0B06059289E12B782385EC68CA5F7B50A3183A40E58317B3017677217623E42F04AC6540BC2D368BD6304DA471195DF890E7A9EA9279203B2B720ED65A756D3DB11CF6AFB270FBC37FD2DA99F61688BBED99D7372FFD78B6C2554CF54991E6973EA1B0B88659BEE418C695D82CFF1555AE46F7C16790A00798E32A37D33F3E3C3AE6E070F7079A7696E76124B9B992E3D3B2CB36418A292AF8DA9B446A9962C821C1967D080FD32EC951ECF9D4FF77D9E6C4BBFCC7B7BAD93BEF3A238B7CE21D7AFFD92E81341C1F3FF61E6107D8B12587B6428E4D9E40163C824CCC63EDC80E028A9512FEB18FF00040D3EF43F46964199335D903A1A6A141FB05D112D2F2FF73556D01235DD194E3430EB12E1274C821641C9993A9AC9F886B64BA77752D2DB62F7B7CC1EF439D282C3F67369282EA73250D2C329FB391B2C07B9C5619590EC67770362E1665CF19D90E444F4AF2D8912321CF4B7DAD1A328A1B21E0CF39A32C87970B092FB01B78B951CDB044C33A5C3A398F8EB6839D73B7A434AA9C33AA0C685CFF09C71601EDFB505119DE98B31590C08939F7FB05383153256B1B8EE1EA486F4F5EB190B0F85AC62CAEDB6D65C5D85B1BBB01D06DF738202345F472160B1100BC06EF681200AFC1B418002F87D6B9F7BEC54C0B7B82D4BA9C6D498B7E0D66FBB39472AAAD23551B320ABAF1183655779F62B6A89A1B113B09E85FCFAEAB01D1E3ADD7717A61DA12264E7AD5254BA735839312014C24A4E8E42A19D1D161CE74D900CE11020CEEA18718C229B028CCEF9AE96556ACAE06B1E455C88CDDEAED4A68FA6EF2A743C3334561DC19E4A2B5A0BA04599C4488EC6467BF3014FB362663D9511B17CEAF11685900A0EEB720E81FC4D87A6C3B9186BE4DC79D9BB26BA998D4391920197BE09718428F76900683A0F7AC6D8D2301D0244D8DB3FEAF039CCF1440B4C1C39818DE93071C198459BA0DDAE374A8A0DF170CA8332B612179AFD052D848D9CE6D850590E780E3EA2856A3C56D1902E1F80A4EB4EA8418DD2976E712D403C3696CEBBF1BA9B1D8022694983D00D3142182F8451B889459BD6F3FF5C3FBC2445581600D3E95D08F1992A6B41757409B32E20E313865E45D2274CAE83B83EF94127706ED29A3AEC2FD544A8E5E54655F69A5C94278F913B75CC07AC498FF86EBD31CEEB4C55B33443D55E411C9E316B2D4358939EB898DF724C0097B8B35989D1E5FD59431F24426855B46CF4939953D60CD3820B096589FD68C7380F1AAD10BC3D4BA2D272D3713B264C01126AF967DC3FC3D47F6607A263801B8E577782D1AE91049D931862DEB5E9863B6327EC330504EE5F4DCC2D40E5F410BE6EC070EED76DB12E7AFE9F05A770B336B2C7C234CCF024956CC1926A7BA4D523C8BAB7E9DC31CAD3A127342338101739E6BBFB94C1ED2E660C98DA8F9847BEDF319621092C3DE5986D1030830A90E609E977F0EF42B8836856AC4F730BC4CAE3778BDC164CA30BE8F98BFAA5A1C4F75FD9770B9EC98E7D7EBF2CF50BA980219262A5E125E271F36280ADB715F481E1A294814E7DEFAC96BB196B878FABA7A69295DA58921A19A7DED71FD16C6EB8810CBAF9325788243C67697C34F7005829726F55B4DA47F2158B6CFCF11586520CE6B1A5D7BF293C870183FFFFC3F53436EE630960000 , N'6.1.3-40302')

