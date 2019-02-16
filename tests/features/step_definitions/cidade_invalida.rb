Quando("digito uma cidade inválida") do
	isit('/buscar-ubs.html')
    fill_in(id: 'cidade', with: 'Cidade JNJ')
    find('input[value="Buscar UBS"]').click
end

Entao("verifico se um erro é exibido") do
	texto = find('#notice')
    expect(texto.text).to eql 'A cidade deigitada é inválida'
end