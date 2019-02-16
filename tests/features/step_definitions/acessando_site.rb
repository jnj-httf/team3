Quando("acesso a URL") do
    visit('/buscar-ubs.html')
end

Então("eu verifico se estou na página correta") do
    expect(page).to have_current_path('https://drbrown.local/team3/template/pages/table/buscar-ubs.html', url:true)
end